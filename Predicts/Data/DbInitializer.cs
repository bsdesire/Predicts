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
        }
    }
}
