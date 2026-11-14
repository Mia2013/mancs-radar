using mancs_radar_server.Data;
using mancs_radar_server.DTOs;
using mancs_radar_server.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace mancs_radar_server.Services
{
    public class DogService : IDogService
    {
        private readonly MancsRadarDbContext _context;

        public DogService(MancsRadarDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> GetAllAsync(double? latitude, double? longitude, double? radiusMeters, ReportType? reportType, ReportStatus? status, DogSize? size, int? breedId)
        {
            try
            {
                var query = _context.Dogs
                    .Include(d => d.Breed)
                    .AsQueryable();

                if (reportType.HasValue)
                    query = query.Where(d => d.ReportType == reportType.Value);

                if (status.HasValue)
                    query = query.Where(d => d.Status == status.Value);

                if (size.HasValue)
                    query = query.Where(d => d.Size == size.Value);

                if (breedId.HasValue)
                    query = query.Where(d => d.BreedId == breedId.Value);

                if (latitude.HasValue && longitude.HasValue && radiusMeters.HasValue && radiusMeters > 0)
                {
                    var centerPoint = GeoHelper.CreatePoint(latitude.Value, longitude.Value);
                    query = query.Where(d => d.LastSeenLocation != null && d.LastSeenLocation.Distance(centerPoint) <= radiusMeters.Value);
                }

                var dogs = await query
                    .OrderByDescending(d => d.CreatedAt)
                    .ToListAsync();

                var dtos = dogs.Select(d => DogResponseDto.FromDog(d)).ToList();

                return ServiceResult.Ok("Kutyák sikeresen lekérdezve!", dtos);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(500, $"Hiba a kutyák lekérdezésekor: {ex.Message}");
            }
        }

        public async Task<ServiceResult> CreateAsync(CreateDogDto dto, int? userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.ContactInfo) && userId == null)
                    return ServiceResult.Fail(400, "Vendégbejelentéshez szükséges az elérhetőség!");

                var dog = new Dog
                {
                    Name = dto.Name,
                    BreedType = dto.BreedType,
                    BreedId = dto.BreedId,
                    Sex = dto.Sex,
                    Size = dto.Size,
                    Color = dto.Color,
                    Description = dto.Description,
                    ChipNumber = dto.ChipNumber,
                    ReportType = dto.ReportType,
                    Status = ReportStatus.Active,
                    LastSeenAt = dto.LastSeenAt,
                    CreatedAt = DateTime.UtcNow,
                    ContactInfo = dto.ContactInfo
                };

                if (userId.HasValue)
                {
                    dog.ReporterUserId = userId.Value;
                }
                else
                {
                    dog.EditPinCode = GeneratePinCode();
                }

                if (dto.AddressId.HasValue)
                {
                    var address = await _context.Addresses.FindAsync(dto.AddressId.Value);
                    if (address == null)
                        return ServiceResult.Fail(404, "A megadott cím nem található!");

                    dog.LastSeenAddressId = address.Id;
                    dog.LastSeenLocation = address.Location;
                    dog.City = address.City;
                    dog.District = address.District;
                }
                else if (dto.Latitude.HasValue && dto.Longitude.HasValue)
                {
                    dog.LastSeenLocation = GeoHelper.CreatePoint(dto.Latitude.Value, dto.Longitude.Value);
                    dog.City = dto.City;
                    dog.District = dto.District;
                }
                else
                {
                    return ServiceResult.Fail(400, "Szükséges a cím (AddressId) vagy a koordináták (Latitude/Longitude)!");
                }

                _context.Dogs.Add(dog);
                await _context.SaveChangesAsync();

                var response = DogResponseDto.FromDog(dog, includePin: !userId.HasValue);
                return ServiceResult.Ok("Kutya sikeresen rögzítve!", response);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(500, $"Hiba a kutya rögzítésekor: {ex.Message}");
            }
        }

        private static string GeneratePinCode()
        {
            return RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6");
        }
    }
}
