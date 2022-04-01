using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class PassageiroMap : IEntityTypeConfiguration<Passageiro>
    {
        public void Configure(EntityTypeBuilder<Passageiro> builder)
        {

            builder.Property(c => c.Sexo)
                 .HasConversion<string>()
                 .HasMaxLength(50);

        }
    }
}
