using mancs_radar_server.DTOs;

namespace mancs_radar_server.Services
{
    public interface IAuthService
    {
        Task<ServiceResult> RegisterAsync(RegisterDTO dto);
        Task<ServiceResult> LoginAsync(LoginDTO dto);
    }
}