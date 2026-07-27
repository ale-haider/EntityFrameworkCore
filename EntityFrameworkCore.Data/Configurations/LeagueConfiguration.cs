using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {


            builder.HasData(
                    new League
                    {
                        Id = 1,
                        Name = "Pakistan Premiere League",
                    },
                    new League
                    {
                        Id = 2,
                        Name = "La Liga",
                    },
                    new League
                    {
                        Id = 3,
                        Name = "English Premiere League",
                    }
                );
        }
    }


}
