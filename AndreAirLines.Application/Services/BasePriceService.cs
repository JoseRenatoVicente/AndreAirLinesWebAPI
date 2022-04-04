using AndreAirLines.Application.Services.Interfaces;
using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirLines.Application.Services
{
    public class BasePriceService : IBasePriceService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IClassRepository _classRepository;
        private readonly IBasePriceRepository _basePriceRepository;

        public BasePriceService(IAirportRepository airportRepository, IClassRepository classRepository, IBasePriceRepository basePriceRepository)
        {
            _airportRepository = airportRepository;
            _classRepository = classRepository;
            _basePriceRepository = basePriceRepository;
        }

        public async Task<IEnumerable<BasePrice>> GetAllBasePricesAsync()
        {
            var iquerable = await _basePriceRepository.GetAllAsync();

            return iquerable.OrderBy(c => c.CreationDate);
        }

        public async Task<BasePrice> GetBasePriceByIdAsync(Guid id)
        {
            return (await _basePriceRepository.GetAllAsync(c => c.Class, c => c.Origin, c => c.Destination))
                .Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<BasePrice> GetBasePriceByOriginDestintionAsync(string destination, string origin, Guid classId)
        {
            return (await _basePriceRepository.GetAllAsync(c => c.Class, c => c.Origin, c => c.Destination))
                .Where(c => c.Destination.Acronym == destination 
                && c.Origin.Acronym == origin
                && c.Class.Id == classId).FirstOrDefault();
        }

        public async Task<BasePrice> AddAsync(BasePrice basePrice)
        {
            var @class = await _classRepository.FindAsync(c => c.Id == basePrice.Class.Id);
            var origin = await _airportRepository.FindAsync(c => c.Acronym == basePrice.Origin.Acronym);
            var destination = await _airportRepository.FindAsync(c => c.Acronym == basePrice.Destination.Acronym);

            if (@class is not null) basePrice.Class = @class;
            if (origin is not null) basePrice.Origin = origin;
            if (destination is not null) basePrice.Destination = destination;

            await _basePriceRepository.AddAsync(basePrice);

            return basePrice;

        }

        public async Task<BasePrice> UpdateAsync(BasePrice basePrice)
        {
            var @class = await _classRepository.FindAsync(c => c.Id == basePrice.Class.Id);
            var origin = await _airportRepository.FindAsync(c => c.Acronym == basePrice.Origin.Acronym);
            var destination = await _airportRepository.FindAsync(c => c.Acronym == basePrice.Destination.Acronym);

            if (@class is not null) basePrice.Class = @class;
            if (origin is not null) basePrice.Origin = origin;
            if (destination is not null) basePrice.Destination = destination;

            await _basePriceRepository.UpdateAsync(basePrice);
            return basePrice;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _basePriceRepository.RemoveAsync(await _basePriceRepository.FindAsync(c => c.Id == id));
        }
    }
}
