namespace mancs_radar_server.Services
{
    public interface IBreedService
    {
        Task<ServiceResult> GetAllAsync();
    }
}
