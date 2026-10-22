namespace mancs_radar_server.Services
{
    public interface IDogService
    {
        Task<ServiceResult> GetAllAsync();

    }
}
