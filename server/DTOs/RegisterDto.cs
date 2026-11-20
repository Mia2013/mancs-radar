using System.ComponentModel.DataAnnotations;

namespace mancs_radar_server.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Az email cím megadása kötelező!")]
        [EmailAddress(ErrorMessage = "Érvénytelen email cím!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A jelszó megadása kötelező!")]
        [MinLength(8, ErrorMessage = "A jelszónak legalább 8 karakter hosszúnak kell lennie!")]
        public string Password { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Érvénytelen telefonszám!")]
        public string? PhoneNumber { get; set; }
    }
}