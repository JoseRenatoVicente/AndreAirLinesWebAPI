using System;

namespace AndreAirLines.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
    }
}
