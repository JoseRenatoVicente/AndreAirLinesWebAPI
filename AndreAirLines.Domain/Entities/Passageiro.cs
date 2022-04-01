using AndreAirLines.API.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLines.Domain.Entities
{
    public class Passageiro
    {
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public Passageiro()
        {

        }
    }
}
