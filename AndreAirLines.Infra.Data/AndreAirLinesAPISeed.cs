using AndreAirLines.API.Models.Enums;
using AndreAirLines.Domain.Entities;
using System;
using System.Linq;

namespace AndreAirLines.Infra.Data
{
    public class AndreAirLinesAPISeed
    {
        private readonly AndreAirLinesAPIContext _context;

        public AndreAirLinesAPISeed(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        public async void Seed()
        {

            Aircraft aircraft1 = new Aircraft
            {
                Id = "ANT1",
                Name = "ANTONOV",
                Capacity = 100

            };

            Aircraft aircraft2 = new Aircraft
            {
                Id = "A330",
                Name = "Airbus",
                Capacity = 100
            };

            if (!_context.Aircraft.Any())
                await _context.Aircraft.AddRangeAsync(aircraft1, aircraft2);

            Airport airport1 = new Airport
            {
                Acronym = "A1",
                Name = "Porto de galinhas",
                Address = new Address
                {
                    Street = "Rua 1"
                }
            };

            Airport airport2 = new Airport
            {
                Acronym = "A2",
                Name = "Porto de congonhas",
                Address = new Address
                {
                    Street = "Rua 2"
                }
            };

            if (!_context.Airport.Any())
                await _context.Airport.AddRangeAsync(airport1, airport2);


            Class class1 = new Class
            {
                Description = "Economy Class"
            };

            Class class2 = new Class
            {
                Description = "Business Class"
            };

            Class class3 = new Class
            {
                Description = "First Class"
            };

            if (!_context.Class.Any())
                await _context.Class.AddRangeAsync(class1, class2, class3);


            BasePrice basePrice1 = new BasePrice
            {
                Destination = airport1,
                Origin = airport2,
                Class = class1,
                Price = 150,
                PercentagePromotion = 10

            };

            BasePrice basePrice2 = new BasePrice
            {
                Destination = airport1,
                Origin = airport2,
                Class = class2,
                Price = 200,
                PercentagePromotion = 20

            };

            BasePrice basePrice3 = new BasePrice
            {
                Destination = airport1,
                Origin = airport2,
                Class = class3,
                Price = 400,
                PercentagePromotion = 20

            };

            if (!_context.BasePrice.Any())
                await _context.BasePrice.AddRangeAsync(basePrice1, basePrice2, basePrice3);

            Flight flight1 = new Flight
            {
                Destination = airport1,
                Origin = airport2,
                Aircraft = aircraft1,
                DepartureTime = DateTime.Now,
                DisembarkationTime = DateTime.Now.AddHours(4)
            };

            Passenger passenger1 = new Passenger
            {

                Cpf = "4293833939",
                Name = "José Renato",
                BirthDate = DateTime.Now,
                Email = "jose@example.com",
                Phone = "1213132",
                Sex = Sex.Male,
                Address = new Address
                {
                    Street = "Rua 3"
                }

            };

            Passenger passenger2 = new Passenger
            {

                Cpf = "22523434",
                Name = "Rose",
                BirthDate = DateTime.Now,
                Email = "rose@example.com",
                Phone = "31232123",
                Sex = Sex.Female,
                Address = new Address
                {
                    Street = "Rua 4"
                }

            };

            if (!_context.Passenger.Any())
                await _context.Passenger.AddRangeAsync(passenger1, passenger2);

            Ticket ticket1 = new Ticket
            {
                Passenger = passenger1,
                Class = class1,
                Flight = flight1,
                Price = 90
            };

            Ticket ticket2 = new Ticket
            {
                Passenger = passenger2,
                Class = class2,
                Flight = flight1,
                Price = 320
            };

            if (!_context.Ticket.Any())
                await _context.Ticket.AddRangeAsync(ticket1, ticket2);

            await _context.SaveChangesAsync();
        }
    }
}
