using mancs_radar_server.DTOs;
using mancs_radar_server.Models;

namespace mancs_radar_server.Mappings
{
    public static class UserMappings
    {
        public static UserDto ToDto(this User user) => new()
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role
        };

        public static User ToEntity(this RegisterDTO dto) => new()
        {
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Role = Roles.User
        };
    }
}
