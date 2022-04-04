using AndreAirLines.API.Models.Enums;
using System;

namespace AndreAirLines.Domain.Entities
{
    public class Passenger
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public Passenger()
        {

        }
    }
}
