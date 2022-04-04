using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class AirportMap : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(c => c.Acronym);
            builder.Property(c => c.Acronym)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(60)");

        }
    }
}