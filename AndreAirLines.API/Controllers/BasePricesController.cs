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
    public class BasePricesController : ControllerBase
    {
        private readonly IBasePriceService _basePriceService;
        public BasePricesController(IBasePriceService basePriceService)
        {
            _basePriceService = basePriceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasePrice>>> GetBasePrice()
        {
            return Ok(await _basePriceService.GetAllBasePricesAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<BasePrice>> GetBasePrice(Guid id)
        {
            var basePrice = await _basePriceService.GetBasePriceByIdAsync(id);

            if (basePrice == null)
            {
                return NotFound();
            }

            return basePrice;
        }

        /*[HttpGet("/OriginDestination")]
        public async Task<ActionResult<BasePrice>> GetBasePrice(string destination, string origin, Guid classId)
        {
            var basePrice = await _basePriceService.GetBasePriceByOriginDestintionAsync(destination, origin, classId);

            if (basePrice == null)
            {
                return NotFound();
            }

            return basePrice;
        }*/

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutBasePrice(Guid id, BasePrice basePrice)
        {
            return id != basePrice.Id ? BadRequest() : Ok(await _basePriceService.UpdateAsync(basePrice));
        }

        [HttpPost]
        public async Task<ActionResult<BasePrice>> PostBasePrice(BasePrice basePrice)
        {
            await _basePriceService.AddAsync(basePrice);

            return CreatedAtAction("GetBasePrice", new { id = basePrice.Id }, basePrice);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBasePrice(Guid id)
        {
            await _basePriceService.RemoveAsync(id);
            return NoContent();
        }
    }
}
