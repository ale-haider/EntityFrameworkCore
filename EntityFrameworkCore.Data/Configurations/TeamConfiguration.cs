using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasIndex(q => q.Name).IsUnique();
            builder.HasMany(n => n.HomeMatches)
                .WithOne(q => q.HomeTeam)
                .HasForeignKey(q => q.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
   
            
            
            builder.HasMany(n => n.AwayMatches)
                .WithOne(q => q.AwayTeam)
                .HasForeignKey(q => q.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new Team
                    {
                        Id = 1,
                        Name = "Spain ",
                        LeagueId = 1,
                        CreatedDate = new DateTime(2026, 7, 22),
                        CoachId = 1,

                    },
                    new Team
                    {
                        Id = 2,
                        Name = "France ",
                        LeagueId = 1,
                        CreatedDate = new DateTime(2026, 7, 22),
                        CoachId = 2,
                    },
                    new Team
                    {
                        Id = 3,
                        Name = "Argentina ",
                        LeagueId = 1,
                        CreatedDate = new DateTime(2026, 7, 22),
                        CoachId = 3,
                    }
                );

        }
    }


}
