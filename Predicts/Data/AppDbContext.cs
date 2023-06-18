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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between players and teams
            builder.Entity<Team>()
                .HasMany(x => x.Players) // A team can have many players
                .WithOne(x => x.CurrentTeam) // The 'CurrentTeam' property in the Player entity refers to the Team
                .HasForeignKey(x => x.CurrentTeamId); // Foreign key relationship using the 'CurrentTeamId' property in the Player entity

            // Seed database with players and teams
            new DbInitializer(builder).Seed();
        }
    }
}
