using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Predicts.Services;

namespace Predicts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly IPredictsService _predictsService;

        public TeamsController(IPredictsService predictsService)
        {
            _predictsService = predictsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _predictsService.GetTeamsAsync();

            if(teams == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, teams);
        }
    }
}
