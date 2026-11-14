using mancs_radar_server.DTOs;
using mancs_radar_server.Models;

namespace mancs_radar_server.Services
{
    public interface IDogService
    {
        Task<ServiceResult> GetAllAsync(double? latitude, double? longitude, double? radiusMeters, ReportType? reportType, ReportStatus? status, DogSize? size, int? breedId);
        Task<ServiceResult> CreateAsync(CreateDogDto dto, int? userId);
    }
}
