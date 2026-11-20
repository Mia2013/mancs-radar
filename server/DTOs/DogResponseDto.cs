using mancs_radar_server.Models;

namespace mancs_radar_server.DTOs
{
    public class DogResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public BreedType BreedType { get; set; }
        public int? BreedId { get; set; }
        public string? BreedName { get; set; }
        public DogSex Sex { get; set; }
        public DogSize Size { get; set; }
        public ICollection<string> Color { get; set; } = [];
        public string? Description { get; set; }
        public string? ChipNumber { get; set; }

        public ReportType ReportType { get; set; }
        public ReportStatus Status { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }

        public DateTime LastSeenAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? ReporterUserId { get; set; }
        public int? ReporterShelterId { get; set; }

        public string? ContactInfo { get; set; }
        public string? EditPinCode { get; set; }
    }
}
