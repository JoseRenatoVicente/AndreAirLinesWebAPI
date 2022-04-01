using System;

namespace AndreAirLines.Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Endereco()
        {

        }

        public Endereco(string bairro, string cidade, string cEP, string logradouro, string estado)
        {
            Bairro = bairro;
            Cidade = cidade;
            CEP = cEP;
            Logradouro = logradouro;
            Estado = estado;
        }
    }
}
