namespace mancs_radar_server.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }

        public static ServiceResult Ok(string message, object? data = null)
            => new() { Success = true, StatusCode = 200, Message = message, Data = data };

        public static ServiceResult Fail(int statusCode, string message)
            => new() { Success = false, StatusCode = statusCode, Message = message };
    }
}