using System;

namespace AndreAirLines.Domain.Entities
{
    public class Voo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Aeroporto Destino { get; set; }
        public Aeroporto Origem { get; set; }
        public Aeronave Aeronave { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesembarque { get; set; }
    }
}
