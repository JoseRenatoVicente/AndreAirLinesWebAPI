using AndreAirLines.Application.Services;
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
    public class AirportsController : ControllerBase
    {
        private readonly ViaCepService _viaCepService;
        private readonly AndreAirLinesAPIContext _context;

        public AirportsController(ViaCepService viaCepService, AndreAirLinesAPIContext context)
        {
            _viaCepService = viaCepService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAeroporto()
        {
            return await _context.Airport.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetAeroporto(int id)
        {
            var aeroporto = await _context.Airport.FindAsync(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(string acronym, Airport aeroporto)
        {
            if (acronym != aeroporto.Acronym)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(acronym))
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

        [HttpPost]
        public async Task<ActionResult<Airport>> PostAeroporto(Airport aeroporto)
        {
            var endereco = await _viaCepService.ConsultarCEP(aeroporto.Address.CEP);

            if (endereco is not null) aeroporto.Address = endereco;

            _context.Airport.Add(aeroporto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAeroporto", new { Acronym = aeroporto.Acronym }, aeroporto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(int id)
        {
            var aeroporto = await _context.Airport.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Airport.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(string acronym)
        {
            return _context.Airport.Any(e => e.Acronym == acronym);
        }
    }
}
