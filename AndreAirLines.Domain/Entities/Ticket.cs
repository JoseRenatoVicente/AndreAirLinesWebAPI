using System;

namespace AndreAirLines.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
        public decimal Price { get; set; }
        public Class Class { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
