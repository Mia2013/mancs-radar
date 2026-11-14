using mancs_radar_server.DTOs;
using mancs_radar_server.Models;
using mancs_radar_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace mancs_radar_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] double? latitude,
            [FromQuery] double? longitude,
            [FromQuery] double? radiusMeters,
            [FromQuery] ReportType? reportType,
            [FromQuery] ReportStatus? status,
            [FromQuery] DogSize? size,
            [FromQuery] int? breedId)
        {
            var result = await _dogService.GetAllAsync(latitude, longitude, radiusMeters, reportType, status, size, breedId);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDogDto dto)
        {
            int? userId = null;
            if (int.TryParse(User.FindFirst("id")?.Value, out var id))
            {
                userId = id;
            }

            var result = await _dogService.CreateAsync(dto, userId);
            return StatusCode(result.StatusCode, result);
        }
    }
}
