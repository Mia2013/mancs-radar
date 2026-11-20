using mancs_radar_server.Models;

namespace mancs_radar_server.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public Roles Role { get; set; } = Roles.User;
    }
}
