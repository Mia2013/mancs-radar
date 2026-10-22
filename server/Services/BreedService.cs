using mancs_radar_server.Data;
using mancs_radar_server.DTOs;
using Microsoft.EntityFrameworkCore;

namespace mancs_radar_server.Services
{
    public class BreedService : IBreedService
    {
        private readonly MancsRadarDbContext _context;

        public BreedService(MancsRadarDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> GetAllAsync()
        {
            var breeds = await _context.DogBreed
                .OrderBy(b => b.Name)
                .Select(b => DogBreedDto.FromDogBreed(b))
                .ToListAsync();

            return ServiceResult.Ok("Fajták sikeresen lekérdezve!", breeds);
        }
    }
}