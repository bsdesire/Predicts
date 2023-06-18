using Microsoft.EntityFrameworkCore;
using Predicts.Data;
using Predicts.Models;

namespace Predicts.Services
{
    public class PredictsService : IPredictsService
    {
        private readonly AppDbContext _db;

        public PredictsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            try
            {
                return await _db.Players.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            try
            {
                return await _db.Players.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Player>> GetPlayersFromTeamAsync(int id)
        {
            try
            {
                return await _db.Players.Where(p => p.CurrentTeamId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Team> GetTeamAsync(int id)
        {
            try
            {
                return await _db.Teams.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            try
            {
                return await _db.Teams.Include(p => p.Players).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Map> GetMapAsync(int id)
        {
            try
            {
                return await _db.Maps.Include(t => t.Match).FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Map>> GetMapsAsync()
        {
            try
            {
                return await _db.Maps
                    .Include(m => m.Match.Team1)
                    .ThenInclude(t => t.Players)
                    .Include(m => m.Match.Team2)
                    .ThenInclude(t => t.Players)
                    .IgnoreAutoIncludes()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Map>> GetMapsFromMatchAsync(int id)
        {
            try
            {
                return await _db.Maps.Include(m => m.Match).Where(m => m.MatchId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Match> GetMatchAsync(int id)
        {
            try
            {
                return await _db.Matches.Include(m => m.Maps).FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Match>> GetMatchesAsync()
        {
            try
            {
                return await _db.Matches.Include(m => m.Maps).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Match>> GetMatchesFromTournamentAsync(int id)
        {
            try
            {
                return await _db.Matches.Include(m => m.Maps).Where(m => m.TournamentId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Tournament> GetTournamentAsync(int id)
        {
            try
            {
                return await _db.Tournaments.Include(t => t.Matches).FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Tournament>> GetTournamentsAsync()
        {
            try
            {
                return await _db.Tournaments.Include(t => t.Matches).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
