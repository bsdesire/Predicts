using Microsoft.EntityFrameworkCore;
using Predicts.Models;

namespace Predicts.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Team>(b =>
            {
                b.HasData(new Team
                {
                    Id = 1,
                    Country = "Europe",
                    Name = "Vitality"
                });

                b.HasData(new Team
                {
                    Id = 2,
                    Country = "Sweden",
                    Name = "Ninjas in Pajamas"
                });
            });

            _builder.Entity<Player>(a =>
            {
                a.HasData(new Player
                {
                    Id = 1,
                    Age = 30,
                    CurrentTeamId = 1,
                    Name = "dupreeh"
                });
                a.HasData(new Player
                {
                    Id = 2,
                    Age = 25,
                    CurrentTeamId = 1,
                    Name = "Magisk"
                });
            });

            _builder.Entity<Tournament>(a =>
            {
                a.HasData(new Tournament
                {
                    Id = 1,
                    Name = "The Test Tournament 2023"
                });
            });

            _builder.Entity<Match>(a =>
            {
                a.HasData(new Match
                {
                    Id = 1,
                    Team1Id = 1,
                    Team2Id = 2,
                    ScoreTeam1 = 2,
                    ScoreTeam2 = 0,
                    TournamentId = 1
                });
            });

            _builder.Entity<Map>(a =>
            {
                a.HasData(new Map
                {
                    Id = 1,
                    MapName = "de_inferno",
                    MatchId = 1,
                    ScoreTeam1 = 16,
                    ScoreTeam2 = 13
                });
                a.HasData(new Map
                {
                    Id = 2,
                    MapName = "de_mirage",
                    MatchId = 1,
                    ScoreTeam1 = 16,
                    ScoreTeam2 = 12
                });
            });
        }
    }
}
