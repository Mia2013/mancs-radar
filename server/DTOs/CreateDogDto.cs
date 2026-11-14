using mancs_radar_server.Models;

namespace mancs_radar_server.DTOs
{
    public class CreateDogDto
    {
        public string? Name { get; set; }
        public BreedType BreedType { get; set; } = BreedType.Unknown;
        public int? BreedId { get; set; }
        public DogSex Sex { get; set; } = DogSex.Unknown;
        public DogSize Size { get; set; }
        public ICollection<string> Color { get; set; } = [];
        public string? Description { get; set; }
        public string? ChipNumber { get; set; }

        public ReportType ReportType { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? AddressId { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }

        public DateTime LastSeenAt { get; set; }

        public string? ContactInfo { get; set; }
    }
}
