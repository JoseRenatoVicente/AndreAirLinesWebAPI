using AndreAirLines.Application.Services.Interfaces;
using AndreAirLines.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return Ok(await _ticketService.GetAllTicketsAsync());
        }

        [HttpGet("{initialDate}/{finalDate}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetPassagemDate(string initialDate, string finalDate)
        {
            var ticket = await _ticketService.GetTicketsByDateAsync(DateTime.Parse(initialDate), DateTime.Parse(finalDate));

            return ticket == null ? NotFound() : Ok(ticket);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Ticket>> GetTicket(Guid id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            return ticket == null ? NotFound() : ticket;
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutPassagem(Guid id, Ticket ticket)
        {
            return id != ticket.Id ? BadRequest() : Ok(await _ticketService.UpdateAsync(ticket));
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            await _ticketService.AddAsync(ticket);

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            await _ticketService.RemoveAsync(id);
            return NoContent();
        }


    }
}
