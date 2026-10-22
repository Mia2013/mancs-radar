namespace mancs_radar_server.Models
{
    public class DogBreed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DogSize DogSize { get; set; }
        public ICollection<string> Color { get; set; } = [];

    }
}
