using mancs_radar_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace mancs_radar_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : Controller
    {
        readonly IBreedService _breedService;
        public BreedsController(IBreedService breedService) => _breedService = breedService;

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _breedService.GetAllAsync();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
