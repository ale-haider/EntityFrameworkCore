using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }

        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($" Data Source={DbPath}")
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)  //// enabling this stops updates in data
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

    //internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    //{
    //    public void Configure ( EntityTypeBuilder<League> builder )
    //    {
    //        builder.HasData(
    //                new League
    //                {
    //                    Id = 1,
    //                    Name = "Barcalona",
                        
    //                },
    //               new League
    //               {
    //                    Id = 2,
    //                    Name = "Humble Lions F.C.",

    //                },
    //                new League
    //                {
    //                    Id = 3,
    //                    Name = "Barcalona",
        
    //                }
    //            ); 
    //    }
    //}
}
