using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.Property(c => c.Description)
                .HasColumnType("varchar(100)"); ;
        }
    }
}