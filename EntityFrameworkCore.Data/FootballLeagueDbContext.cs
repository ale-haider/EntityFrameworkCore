using EntityFrameworkCore.Data.Configurations;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
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
                .UseLazyLoadingProxies()
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)  //// enabling this stops updates in data
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                 .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TeamConfiguration());
            //modelBuilder.ApplyConfiguration(new LeagueConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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
    //            dddd        Id = 3,
    //                    Name = "Barcalona",
        
    //                }
    //            ); 
    //    }
    //}
}
