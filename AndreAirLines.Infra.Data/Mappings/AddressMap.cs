using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(c => c.District)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.City)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.Country)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.CEP)
                 .HasColumnType("varchar(15)");

            builder.Property(c => c.Street)
                  .HasColumnType("varchar(60)");

            builder.Property(c => c.State)
                  .HasColumnType("varchar(5)");

            builder.Property(c => c.Number)
                  .HasColumnType("varchar(20)");

            builder.Property(c => c.Complement)
                  .HasColumnType("varchar(200)");

        }
    }
}
