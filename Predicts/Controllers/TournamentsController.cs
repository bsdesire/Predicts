using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Predicts.Services;

namespace Predicts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : Controller
    {
        private readonly IPredictsService _predictsService;

        public TournamentsController(IPredictsService predictsService)
        {
            _predictsService = predictsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            var tournaments = await _predictsService.GetTournamentsAsync();

            if (tournaments == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, tournaments);
        }

        [HttpGet("tournamentId/{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            var tournament = await _predictsService.GetTournamentAsync(id);

            if (tournament == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, tournament);
        }
    }
}
