namespace AndreAirLines.Domain.Entities
{
    public class Aeroporto
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

    }
}
