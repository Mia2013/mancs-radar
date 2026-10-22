using System.ComponentModel.DataAnnotations;

namespace mancs_radar_server.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Az email cím megadása kötelező!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A jelszó megadása kötelező!")]
        public string Password { get; set; } = string.Empty;
    }
}