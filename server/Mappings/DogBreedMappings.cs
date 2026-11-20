using mancs_radar_server.DTOs;
using mancs_radar_server.Models;

namespace mancs_radar_server.Mappings
{
    public static class DogBreedMappings
    {
        public static DogBreedDto ToDto(this DogBreed breed) => new()
        {
            Id = breed.Id,
            Name = breed.Name,
            Size = breed.DogSize,
            Colors = breed.Color
        };
    }
}
