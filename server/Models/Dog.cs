using NetTopologySuite.Geometries;
using System.Collections;

namespace mancs_radar_server.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string? Name { get; set; } =string.Empty;
        public BreedType BreedType { get; set; } = BreedType.Unknown;
        public int? BreedId { get; set; }
        public DogBreed? Breed { get; set; }
        public DogSex Sex { get; set; } = DogSex.Unknown;
        public DogSize Size { get; set; }
        public ICollection<string> Color { get; set; } = [];
        public string? Description { get; set; }
        public string? ChipNumber { get; set; }

        public ReportType ReportType { get; set; }
        public ReportStatus Status { get; set; } = ReportStatus.Active;

        public Point? LastSeenLocation { get; set; } = null!;
        public Address? LastSeenAddress { get; set; } = null!;
        public DateTime LastSeenAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? ReporterUserId { get; set; }
        public User? ReporterUser { get; set; }

        public int? ReporterShelterId { get; set; }
        public Shelter? ReporterShelter { get; set; }

        public ICollection<DogPhoto> Photos { get; set; } = new List<DogPhoto>();
    }
}