using Predicts.DTOs;
using Predicts.Models;

namespace Predicts.Services
{
    public interface IPredictsService
    {
        // Player Services
        Task<PlayerDTO> GetPlayerAsync(int id);
        Task<List<PlayerDTO>> GetPlayersAsync();
        Task<List<PlayerDTO>> GetPlayersFromTeamAsync(int id);

        // Team Services
        Task<TeamDTO> GetTeamAsync(int id);
        Task<List<TeamDTO>> GetTeamsAsync();

        // Map Services
        Task<MapDTO> GetMapAsync(int id);
        Task<List<MapDTO>> GetMapsAsync();
        Task<List<MapDTO>> GetMapsFromMatchAsync(int id);
        Task<Map> AddMap(MapDTO map);

        // Match Services
        Task<MatchDTO> GetMatchAsync(int id);
        Task<List<MatchDTO>> GetMatchesAsync();
        Task<List<MatchDTO>> GetMatchesFromTournamentAsync(int id);

        // Tournament Services
        Task<TournamentDTO> GetTournamentAsync(int id);
        Task<List<TournamentDTO>> GetTournamentsAsync();
    }
}
