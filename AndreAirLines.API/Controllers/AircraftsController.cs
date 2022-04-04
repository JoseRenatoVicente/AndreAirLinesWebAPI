using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirLines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftsController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public AircraftsController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Aeronaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAeronave()
        {
            return await _context.Aircraft.ToListAsync();
        }

        // GET: api/Aeronaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAeronaveMes(string mes)
        {
            return await _context.Aircraft.ToListAsync();
        }

        // GET: api/Aeronaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetAeronave(string id)
        {
            var aeronave = await _context.Aircraft.FindAsync(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            return aeronave;
        }

        // PUT: api/Aeronaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeronave(string id, Aircraft aeronave)
        {
            if (id != aeronave.Id)
            {
                return BadRequest();
            }

            _context.Entry(aeronave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeronaveExists(id))
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

        // POST: api/Aeronaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aircraft>> PostAeronave(Aircraft aeronave)
        {
            _context.Aircraft.Add(aeronave);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeronaveExists(aeronave.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeronave", new { id = aeronave.Id }, aeronave);
        }

        // DELETE: api/Aeronaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeronave(string id)
        {
            var aeronave = await _context.Aircraft.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }

            _context.Aircraft.Remove(aeronave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeronaveExists(string id)
        {
            return _context.Aircraft.Any(e => e.Id == id);
        }
    }
}
