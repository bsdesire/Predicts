using Predicts.Models;

namespace Predicts.Services
{
    public interface IPredictsService
    {
        // Player Services
        Task<Player> GetPlayerAsync(int id);
        Task<List<Player>> GetPlayersAsync();
        Task<List<Player>> GetPlayersFromTeamAsync(int id);

        // Team Services
        Task<Team> GetTeamAsync(int id);
        Task<List<Team>> GetTeamsAsync();
    }
}
