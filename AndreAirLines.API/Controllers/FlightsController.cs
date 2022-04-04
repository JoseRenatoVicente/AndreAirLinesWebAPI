using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirLines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public FlightsController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Voos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetVoo()
        {
            return await _context.Flight.ToListAsync();
        }

        // GET: api/Voos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetVoo(Guid id)
        {
            var voo = await _context.Flight.FindAsync(id);

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(Guid id, Flight voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Voos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostVoo(Flight voo)
        {

            var origem = await _context.Airport.FindAsync(voo.Origin.Acronym);

            var destino = await _context.Airport.FindAsync(voo.Destination.Acronym);

            var aircraft = await _context.Aircraft.FindAsync(voo.Aircraft.Id);

            if (origem is not null) voo.Origin = origem;
            if (destino is not null) voo.Destination = destino;
            if (aircraft is not null) voo.Aircraft = aircraft;

            _context.Flight.Add(voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoo(Guid id)
        {
            var voo = await _context.Flight.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Flight.Remove(voo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VooExists(Guid id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
