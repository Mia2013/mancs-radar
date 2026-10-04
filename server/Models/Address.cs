using NetTopologySuite.Geometries;

namespace mancs_radar_server.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? District { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string StreetType { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? Door { get; set; }
        public string CountryCode { get; set; } = "HU";
        public Point Location { get; set; } = null!;

        public int? UserId { get; set; }
        public User? User { get; set; }
        public string? Label { get; set; }
        public bool IsPrimary { get; set; }
    }
}