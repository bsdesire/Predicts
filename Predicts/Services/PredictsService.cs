using Microsoft.EntityFrameworkCore;
using Predicts.Data;
using Predicts.DTOs;
using Predicts.Models;
using System.Text.RegularExpressions;
using Match = Predicts.Models.Match;

namespace Predicts.Services
{
    public class PredictsService : IPredictsService
    {
        private readonly AppDbContext _db;

        public PredictsService(AppDbContext db)
        {
            _db = db;
        }

        #region Gets
        public async Task<MapDTO> GetMapAsync(int id)
        {
            try
            {
                var map = await _db.Maps
                    .Include(t => t.Match)
                    .Include(t => t.Match.Team1)
                    .Include(t => t.Match.Team2)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (map == null) return null;

                return new MapDTO
                {
                    MapName = map.MapName,
                    Team1 = new TeamDTO { Name = map.Match.Team1.Name, Country = map.Match.Team1.Country },
                    Team2 = new TeamDTO { Name = map.Match.Team2.Name, Country = map.Match.Team2.Country },
                    ScoreTeam1 = map.ScoreTeam1,
                    ScoreTeam2 = map.ScoreTeam2,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MapDTO>> GetMapsAsync()
        {
            try
            {
                return await _db.Maps
                    .Include(m => m.Match)
                    .Select(m => new MapDTO
                    {
                        ScoreTeam1 = m.ScoreTeam1,
                        ScoreTeam2 = m.ScoreTeam2,
                        MapName = m.MapName,
                        Team1 = new TeamDTO { Name = m.Match.Team1.Name, Country = m.Match.Team1.Country },
                        Team2 = new TeamDTO { Name = m.Match.Team2.Name, Country = m.Match.Team2.Country },
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MapDTO>> GetMapsFromMatchAsync(int id)
        {
            try
            {
                var maps = await _db.Maps
                    .Include(m => m.Match)
                    .Include(m => m.Match.Team1)
                    .Include(m => m.Match.Team2)
                    .Where(m => m.MatchId == id).ToListAsync();

                if (maps == null) return null;

                var mapsList = new List<MapDTO>();

                maps.ForEach(map =>
                {
                    mapsList.Add(new MapDTO
                    {
                        MapName = map.MapName,
                        Team1 = new TeamDTO { Name = map.Match.Team1.Name, Country = map.Match.Team1.Country },
                        Team2 = new TeamDTO { Name = map.Match.Team2.Name, Country = map.Match.Team2.Country },
                        ScoreTeam1 = map.ScoreTeam1,
                        ScoreTeam2 = map.ScoreTeam2,
                    });
                });

                return mapsList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MatchDTO> GetMatchAsync(int id)
        {
            try
            {
                var match = await _db.Matches
                    .Include(m => m.Maps)
                    .Include(m => m.Team1)
                    .Include(m => m.Team2)
                    .Include(m => m.Tournament).FirstAsync(m => m.Id == id);

                var matchDTO = new MatchDTO
                {
                    Maps = new List<MapDTO>(),
                    ScoreTeam1 = match.ScoreTeam1,
                    ScoreTeam2 = match.ScoreTeam2,
                    Team1 = new TeamDTO { Name = match.Team1.Name, Country = match.Team1.Country },
                    Team2 = new TeamDTO { Name = match.Team2.Name, Country = match.Team2.Country },
                    Tournament = new TournamentDTO { Name = match.Tournament.Name }
                };

                foreach (var map in match.Maps)
                {
                    var mapDTO = new MapDTO
                    {
                        MapName = map.MapName,
                        ScoreTeam1 = map.ScoreTeam1,
                        ScoreTeam2 = map.ScoreTeam2
                    };

                    matchDTO.Maps.Add(mapDTO);
                }

                return matchDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MatchDTO>> GetMatchesAsync()
        {
            try
            {
                var matches = await _db.Matches
                    .Include(m => m.Maps)
                    .Include(m => m.Team1)
                    .Include(m => m.Team2)
                    .Include(m => m.Tournament)
                    .ToListAsync();
                var matchesDTO = new List<MatchDTO>();

                foreach (var match in matches) {
                    var matchDTO = new MatchDTO
                    {
                        Maps = new List<MapDTO>(),
                        ScoreTeam1 = match.ScoreTeam1,
                        ScoreTeam2 = match.ScoreTeam2,
                        Team1 = new TeamDTO { Name = match.Team1.Name, Country = match.Team1.Country },
                        Team2 = new TeamDTO { Name = match.Team2.Name, Country = match.Team2.Country },
                        Tournament = new TournamentDTO { Name = match.Tournament.Name }
                    };
                    foreach (var map in match.Maps)
                    {
                        var mapDTO = new MapDTO
                        {
                            MapName = map.MapName,
                            ScoreTeam1 = map.ScoreTeam1,
                            ScoreTeam2 = map.ScoreTeam2
                        };

                        matchDTO.Maps.Add(mapDTO);
                    }
                    matchesDTO.Add(matchDTO);
                }

                return matchesDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MatchDTO>> GetMatchesFromTournamentAsync(int id)
        {
            try
            {
                var matches = await _db.Matches.Include(m => m.Maps)
                    .Include(m => m.Team1)
                    .Include(m => m.Team2)
                    .Include(m => m.Tournament).Where(m => m.TournamentId == id).ToListAsync();
                var matchesDTO = new List<MatchDTO>();

                foreach (var match in matches)
                {
                    var matchDTO = new MatchDTO
                    {
                        Maps = new List<MapDTO>(),
                        ScoreTeam1 = match.ScoreTeam1,
                        ScoreTeam2 = match.ScoreTeam2,
                        Team1 = new TeamDTO { Name = match.Team1.Name, Country = match.Team1.Country },
                        Team2 = new TeamDTO { Name = match.Team2.Name, Country = match.Team2.Country },
                        Tournament = new TournamentDTO { Name = match.Tournament.Name }
                    };
                    foreach (var map in match.Maps)
                    {
                        var mapDTO = new MapDTO
                        {
                            MapName = map.MapName,
                            ScoreTeam1 = map.ScoreTeam1,
                            ScoreTeam2 = map.ScoreTeam2
                        };

                        matchDTO.Maps.Add(mapDTO);
                    }
                    matchesDTO.Add(matchDTO);
                }

                return matchesDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PlayerDTO> GetPlayerAsync(int id)
        {
            try
            {
                var player = await _db.Players
                   .Include(p => p.CurrentTeam)
                   .FirstOrDefaultAsync(p => p.Id == id);

                if (player != null)
                {
                    var playerDTO = new PlayerDTO
                    {
                        Name = player.Name,
                        Age = player.Age,
                        CurrentTeam = new TeamDTO
                        {
                            Name = player.CurrentTeam?.Name,
                            Country = player.CurrentTeam?.Country
                        }
                    };

                    return playerDTO;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PlayerDTO>> GetPlayersAsync()
        {
            try
            {
                var players = await _db.Players
                    .Include(p => p.CurrentTeam)
                    .ToListAsync();
                var playersDTO = new List<PlayerDTO>();

                foreach (var player in players)
                {
                    var playerDTO = new PlayerDTO
                    {
                        Name = player.Name,
                        Age = player.Age,
                        CurrentTeam = new TeamDTO { Name = player.CurrentTeam?.Name, Country = player.CurrentTeam?.Country },
                    };

                    playersDTO.Add(playerDTO);
                }

                return playersDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PlayerDTO>> GetPlayersFromTeamAsync(int id)
        {
            try
            {
                var players = await _db.Players.Include(p => p.CurrentTeam).Where(p => p.CurrentTeamId == id).ToListAsync();
                var playersDTO = new List<PlayerDTO>();

                if (players == null) return null;

                foreach (var player in players)
                {
                    var playerDTO = new PlayerDTO
                    {
                        Name = player.Name,
                        Age = player.Age,
                        CurrentTeam = new TeamDTO { Name = player.CurrentTeam?.Name, Country = player.CurrentTeam?.Country },
                    };

                    playersDTO.Add(playerDTO);
                }

                return playersDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TeamDTO> GetTeamAsync(int id)
        {
            try
            {
                var team = await _db.Teams.FirstAsync(t => t.Id == id);

                if (team == null) return null;

                return new TeamDTO
                {
                    Name = team.Name,
                    Country = team.Country
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TeamDTO>> GetTeamsAsync()
        {
            try
            {
                var teams = await _db.Teams.Include(p => p.Players).ToListAsync();
                var teamsDTO = new List<TeamDTO>();

                if (teams == null) return null;

                foreach (var team in teams)
                {
                    var teamDTO = new TeamDTO
                    {
                        Name = team.Name,
                        Country = team.Country
                    };

                    teamsDTO.Add(teamDTO);
                }

                return teamsDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TournamentDTO> GetTournamentAsync(int id)
        {
            try
            {
                var tournament = await _db.Tournaments.Include(t => t.Matches).FirstOrDefaultAsync(t => t.Id == id);
                var tournamentDTO = new TournamentDTO
                {
                    Name = tournament.Name,
                    Matches = await GetMatchesFromTournamentAsync(tournament.Id)
                };

                return tournamentDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TournamentDTO>> GetTournamentsAsync()
        {
            try
            {
                var tournaments = await _db.Tournaments.Include(t => t.Matches).ToListAsync();
                var tournamentsDTO = new List<TournamentDTO>();

                foreach (var tournament in tournaments)
                {
                    var tournamentDTO = new TournamentDTO
                    {
                        Name = tournament.Name,
                        Matches = await GetMatchesFromTournamentAsync(tournament.Id)
                    };
                    tournamentsDTO.Add(tournamentDTO);
                }

                return tournamentsDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Creates

        public async Task<Map> AddMap(MapDTO map)
        {
            try
            {
                var newMap = new Map
                {
                    MapName = map.MapName,
                    ScoreTeam1 = map.ScoreTeam1,
                    ScoreTeam2 = map.ScoreTeam2,
                };

                await _db.Maps.AddAsync(newMap);
                await _db.SaveChangesAsync();

                return newMap; // Return the newly created Map object with the auto-generated ID
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        #endregion
    }
}