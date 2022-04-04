using AndreAirLines.Application.Services;
using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirLines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;

        private readonly ViaCepService _viaCepService;

        public PassengersController(IPassengerRepository passengerRepository, ViaCepService viaCepService)
        {
            _passengerRepository = passengerRepository;
            _viaCepService = viaCepService;
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Passenger), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassageiro()
        {
            return await (await _passengerRepository.GetAllAsync()).ToListAsync();
        }

        /// <summary>
        /// Retorna um produto específico através de seu Id que é único
        /// </summary>
        /// <remarks>Retorna um produto específico através de seu Id que é único</remarks>
        /// <remarks>Retorna um produto específico através de seu Id que é único</remarks>
        /// <param name="cpf" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">The product id</param>
        /// <response code="200">Sucesso</response>
        /// <response code="400">O produto tem valores ausentes/inválidos</response>
        /// <response code="500">Erro ao retornar produto</response>
        [ProducesResponseType(typeof(Passenger), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IDictionary<string, string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Passenger>> GetPassageiro(string cpf)
        {
            var passageiro = await
                (await _passengerRepository.GetAllAsync(x => x.Address))
                .Where(c => c.Cpf == cpf)
                .FirstOrDefaultAsync();

            if (passageiro == null)
            {
                return NotFound();
            }

            return passageiro;
        }

        // PUT: api/Passageiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutPassageiro(string cpf, Passenger passageiro)
        {
            if (cpf != passageiro.Cpf)
            {
                return BadRequest();
            }

            await _passengerRepository.UpdateAsync(passageiro);

            /*try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassageiroExists(cpf))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/

            return NoContent();
        }

        // POST: api/Passageiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassageiro(Passenger passageiro)
        {
            var address = await _viaCepService.ConsultarCEP(passageiro.Address.CEP);

            if (address is not null) passageiro.Address = address;

            await _passengerRepository.AddAsync(passageiro);

            /*try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassageiroExists(passageiro.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }*/

            return CreatedAtAction("GetPassageiro", new { id = passageiro.Cpf }, passageiro);
        }

        // DELETE: api/Passageiros/5
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeletePassageiro(string cpf)
        {
            var passageiro = await _passengerRepository.FindAsync(c => c.Cpf == cpf);
            if (passageiro == null)
            {
                return NotFound();
            }
            await _passengerRepository.RemoveAsync(passageiro);

            return NoContent();
        }

        private async Task<bool> PassageiroExists(string cpf)
        {
            return await _passengerRepository.Exists(e => e.Cpf == cpf);
        }
    }
}
