using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class AircraftMap : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.Property(c => c.Name)
                .HasColumnType("varchar(60)");
        }
    }
}
