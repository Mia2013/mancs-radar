using mancs_radar_server.Models;

namespace mancs_radar_server.DTOs
{
    public class DogBreedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DogSize Size { get; set; }
        public ICollection<string> Colors { get; set; } = [];
    }
}