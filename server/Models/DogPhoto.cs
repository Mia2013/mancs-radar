namespace mancs_radar_server.Models
{
    public class DogPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsDefault { get; set; }

        public int DogId { get; set; }
        public Dog Dog { get; set; } = null!;
    }
}