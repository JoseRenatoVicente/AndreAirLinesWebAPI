using AndreAirLines.API.Models.Enums;
using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class PassengerMap : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(c => c.Cpf);
            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.Phone)
                 .HasColumnType("varchar(15)");

            builder.Property(c => c.Email)
                  .HasColumnType("varchar(60)");

            builder.Property(c => c.Sex)
                 .HasConversion(p => (char)p, p => (Sex)p)
                 .HasMaxLength(1);
        }
    }
}
