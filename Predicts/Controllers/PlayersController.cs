using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Predicts.Services;

namespace Predicts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPredictsService _predictsService;

        public PlayersController(IPredictsService predictsService)
        {
            _predictsService = predictsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _predictsService.GetPlayersAsync();

            if(players == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, players);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _predictsService.GetPlayerAsync(id);

            if (player == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, player);
        }

        [HttpGet("teamId")]
        public async Task<IActionResult> GetPlayersFromTeam(int teamId)
        {
            var players = await _predictsService.GetPlayersFromTeamAsync(teamId);

            if (players == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, players);
        }
    }
}
