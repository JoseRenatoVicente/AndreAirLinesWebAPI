using AndreAirLines.Application.Services.Interfaces;
using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirLines.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IClassRepository _classRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IBasePriceRepository _basePriceRepository;

        public TicketService(ITicketRepository ticketRepository, IPassengerRepository passengerRepository, IClassRepository classRepository, IFlightRepository flightRepository, IBasePriceRepository basePriceRepository)
        {
            _ticketRepository = ticketRepository;
            _passengerRepository = passengerRepository;
            _classRepository = classRepository;
            _flightRepository = flightRepository;
            _basePriceRepository = basePriceRepository;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByDateAsync(DateTime initialDate, DateTime finalDate)
        {
            return (await _ticketRepository.GetAllAsync(c => c.Class, c => c.Flight, c => c.Passenger))
                .Where(c => c.CreationDate.Date >= initialDate && c.CreationDate.Date <= finalDate);
        }

        public async Task<Ticket> GetTicketByIdAsync(Guid id)
        {
            return (await _ticketRepository.GetAllAsync(c => c.Class, c => c.Flight, c => c.Passenger))
                .Where(c => c.Id == id).FirstOrDefault();
        }


        public async Task<Ticket> AddAsync(Ticket ticket)
        {
            Flight flight = (await _flightRepository.GetAllAsync(
                c => c.Origin, c => c.Destination))
                .Where(c => c.Id == ticket.Flight.Id)
                .FirstOrDefault();

            Passenger passenger = await _passengerRepository.FindAsync(c => c.Cpf == ticket.Passenger.Cpf);
            Class @class = await _classRepository.FindAsync(c => c.Id == ticket.Class.Id);

            BasePrice basePrice = (await _basePriceRepository.FindAllAsync(
                c => c.Origin == flight.Origin
                && c.Destination == flight.Destination
                && c.Class == @class))
                .OrderBy(c => c.CreationDate)
                .FirstOrDefault();

            if (basePrice is null) return null;

            ticket.Price = basePrice.PricePromotion();
            ticket.Flight = flight;
            ticket.Passenger = passenger;
            ticket.Class = @class;

            await _ticketRepository.AddAsync(ticket);

            return ticket;

        }

        public async Task<Ticket> UpdateAsync(Ticket ticket)
        {
            var flight = await _flightRepository.FindAsync(c => c.Id == ticket.Flight.Id);
            var passenger = await _passengerRepository.FindAsync(c => c.Cpf == ticket.Passenger.Cpf);
            var @class = await _classRepository.FindAsync(c => c.Id == ticket.Class.Id);

            if (flight is not null) ticket.Flight = flight;
            if (passenger is not null) ticket.Passenger = passenger;
            if (@class is not null) ticket.Class = @class;

            await _ticketRepository.UpdateAsync(ticket);
            return ticket;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _ticketRepository.RemoveAsync(await _ticketRepository.FindAsync(c => c.Id == id));
        }


    }
}
