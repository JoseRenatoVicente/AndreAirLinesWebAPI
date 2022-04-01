using System;

namespace AndreAirLines.Domain.Entities
{
    public class Passagem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Voo Voo { get; set; }
        public Passageiro Passageiro { get; set; }
    }
}
