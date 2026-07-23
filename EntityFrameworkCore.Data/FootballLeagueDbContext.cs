using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext

    {
        public FootballLeagueDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "FootballLeague_EfCore.db");
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($" Data Source={DbPath}")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                 .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                    new Team
                    {
                        Id = 1,
                        Name = "Spain ",
                        CreatedDate = new DateTime(2026, 7, 22)
                    },
                    new Team
                    {
                        Id = 2,
                        Name = "France ",
                        CreatedDate = new DateTime(2026, 7, 22)
                    },
                    new Team
                    {
                        Id = 3,
                        Name = "Argentina ",
                        CreatedDate = new DateTime(2026, 7, 22)
                    }
                );
        }
    }
}
