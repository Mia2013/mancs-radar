using mancs_radar_server.DTOs;
using mancs_radar_server.Models;

namespace mancs_radar_server.Mappings
{
    public static class DogMappings
    {
        public static DogResponseDto ToDto(this Dog dog, bool includePin = false) => new()
        {
            Id = dog.Id,
            Name = dog.Name,
            BreedType = dog.BreedType,
            BreedId = dog.BreedId,
            BreedName = dog.Breed?.Name,
            Sex = dog.Sex,
            Size = dog.Size,
            Color = dog.Color,
            Description = dog.Description,
            ChipNumber = dog.ChipNumber,
            ReportType = dog.ReportType,
            Status = dog.Status,
            Latitude = dog.LastSeenLocation?.Y,
            Longitude = dog.LastSeenLocation?.X,
            City = dog.City,
            District = dog.District,
            LastSeenAt = dog.LastSeenAt,
            CreatedAt = dog.CreatedAt,
            ReporterUserId = dog.ReporterUserId,
            ReporterShelterId = dog.ReporterShelterId,
            ContactInfo = dog.ContactInfo,
            EditPinCode = includePin ? dog.EditPinCode : null
        };

        public static Dog ToEntity(this CreateDogDto dto) => new()
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
            LastSeenAt = dto.LastSeenAt,
            ContactInfo = dto.ContactInfo
        };
    }
}
