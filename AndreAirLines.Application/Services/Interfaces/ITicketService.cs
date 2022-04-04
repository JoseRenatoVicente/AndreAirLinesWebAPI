using AndreAirLines.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLines.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetTicketsByDateAsync(DateTime initialDate, DateTime finalDate);
        Task<Ticket> GetTicketByIdAsync(Guid id);
        Task<Ticket> AddAsync(Ticket ticket);
        Task<Ticket> UpdateAsync(Ticket ticket);
        Task RemoveAsync(Guid id);
    }
}
