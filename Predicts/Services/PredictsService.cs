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
    }
}
