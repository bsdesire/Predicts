using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Predicts.Services;

namespace Predicts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : Controller
    {
        private readonly IPredictsService _predictsService;

        public MatchesController(IPredictsService predictsService)
        {
            _predictsService = predictsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatches()
        {
            var matches = await _predictsService.GetMatchesAsync();

            if (matches == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, matches);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await _predictsService.GetMatchAsync(id);

            if (match == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, match);
        }

        [HttpGet("/tournamentId/{tournamentId}")]
        public async Task<IActionResult> GetMatchesFromTournament(int tournamentId)
        {
            var matches = await _predictsService.GetMatchesFromTournamentAsync(tournamentId);

            if (matches == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, matches);
        }
    }
}
