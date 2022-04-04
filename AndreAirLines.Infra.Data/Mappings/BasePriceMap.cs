using AndreAirLines.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreAirLines.Infra.Data.Mappings
{
    public class BasePriceMap : IEntityTypeConfiguration<BasePrice>
    {
        public void Configure(EntityTypeBuilder<BasePrice> builder)
        {
            builder.Property(c => c.Price)
                .HasColumnType("decimal(10,4)");

            builder.Property(c => c.PercentagePromotion)
                .HasColumnType("decimal(10,4)");

        }
    }
}