using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Predicts.Services;

namespace Predicts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : Controller
    {
        private readonly IPredictsService _predictsService;

        public MapsController(IPredictsService predictsService)
        {
            _predictsService = predictsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaps()
        {
            var maps = await _predictsService.GetMapsAsync();

            if (maps == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, maps);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMap(int id)
        {
            var map = await _predictsService.GetMapAsync(id);

            if (map == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, map);
        }

        [HttpGet("matchId")]
        public async Task<IActionResult> GetMapsFromMatch(int matchId)
        {
            var maps = await _predictsService.GetMapsFromMatchAsync(matchId);

            if (maps == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, maps);
        }
    }
}
