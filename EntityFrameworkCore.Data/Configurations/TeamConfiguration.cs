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

            builder.HasData(
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
