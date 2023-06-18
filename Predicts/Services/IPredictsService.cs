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

        // Map Services
        Task<Map> GetMapAsync(int id);
        Task<List<Map>> GetMapsAsync();
        Task<List<Map>> GetMapsFromMatchAsync(int id);

        // Match Services
        Task<Match> GetMatchAsync(int id);
        Task<List<Match>> GetMatchesAsync();
        Task<List<Match>> GetMatchesFromTournamentAsync(int id);

        // Tournament Services
        Task<Tournament> GetTournamentAsync(int id);
        Task<List<Tournament>> GetTournamentsAsync();
    }
}
