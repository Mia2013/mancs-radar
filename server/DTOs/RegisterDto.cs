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

        [Required(ErrorMessage = "A keresztnév megadása kötelező!")]
        [MaxLength(100, ErrorMessage = "A keresztnév legfeljebb 100 karakter lehet!")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "A vezetéknév megadása kötelező!")]
        [MaxLength(100, ErrorMessage = "A vezetéknév legfeljebb 100 karakter lehet!")]
        public string LastName { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Érvénytelen telefonszám!")]
        public string? PhoneNumber { get; set; }
    }
}