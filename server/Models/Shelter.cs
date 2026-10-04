namespace mancs_radar_server.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}