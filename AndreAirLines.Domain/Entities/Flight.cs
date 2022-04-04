using System;

namespace AndreAirLines.Domain.Entities
{
    public class Flight
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Airport Destination { get; set; }
        public Airport Origin { get; set; }
        public Aircraft Aircraft { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime DisembarkationTime { get; set; }
    }
}
