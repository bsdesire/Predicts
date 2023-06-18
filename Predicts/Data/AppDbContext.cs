using Microsoft.EntityFrameworkCore;
using Predicts.Models;

namespace Predicts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between players and teams
            builder.Entity<Team>()
                .HasMany(x => x.Players) // A team can have many players
                .WithOne(x => x.CurrentTeam) // The 'CurrentTeam' property in the Player entity refers to the Team
                .HasForeignKey(x => x.CurrentTeamId); // Foreign key relationship using the 'CurrentTeamId' property in the Player entity

            // Define relationship between match and teams
            builder.Entity<Match>()
                .HasOne(x => x.Team1) // A match has one team as Team1
                .WithMany() // No navigation property back to Match from Team1
                .HasForeignKey(x => x.Team1Id); // Foreign key relationship using the 'Team1Id' property in the Match entity

            builder.Entity<Match>()
                .HasOne(x => x.Team2) // A match has one team as Team2
                .WithMany() // No navigation property back to Match from Team2
                .HasForeignKey(x => x.Team2Id); // Foreign key relationship using the 'Team2Id' property in the Match entity

            // Define relationship between players and teams
            builder.Entity<Match>()
                .HasMany(x => x.Maps) // A match can have many maps
                .WithOne(x => x.Match) // The 'Match' property in the Maps entity refers to the Matches
                .HasForeignKey(x => x.MatchId); // Foreign key relationship using the 'MatchId' property in the Map entity

            // Define relationship between players and teams
            builder.Entity<Tournament>()
                .HasMany(x => x.Matches) // A Tournament can have many Matches
                .WithOne(x => x.Tournament) // The 'Tournament' property in the Matches entity refers to the Tournaments
                .HasForeignKey(x => x.TournamentId); // Foreign key relationship using the 'TournamentId' property in the Match entity

            // Seed database with players and teams
            new DbInitializer(builder).Seed();
        }
    }
}
