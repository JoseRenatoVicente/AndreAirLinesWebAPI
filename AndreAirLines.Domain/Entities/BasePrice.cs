using System;

namespace AndreAirLines.Domain.Entities
{
    public class BasePrice
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Airport Destination { get; set; }
        public Airport Origin { get; set; }
        public decimal Price { get; set; }
        public decimal PercentagePromotion { get; set; }
        public Class Class { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public decimal PricePromotion()
        {
            return Price - (Price * (PercentagePromotion / 100));
        }
    }
}
