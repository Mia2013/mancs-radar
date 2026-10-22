using mancs_radar_server.Models;

namespace mancs_radar_server.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public Roles Role { get; set; } = Roles.User;

        public static UserDto FromUser(User user) => new()
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role
        };
    }
}
