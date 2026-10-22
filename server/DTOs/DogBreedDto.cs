using mancs_radar_server.Models;

namespace mancs_radar_server.DTOs
{
    public class DogBreedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DogSize Size { get; set; }
        public ICollection<string> Colors { get; set; } = [];

        public static DogBreedDto FromDogBreed(DogBreed breed) => new()
        {
            Id = breed.Id,
            Name = breed.Name,
            Size = breed.DogSize,
            Colors = breed.Color
        };
    }
}