using AndreAirLines.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLines.Application.Services.Interfaces
{
    public interface IBasePriceService
    {
        Task<IEnumerable<BasePrice>> GetAllBasePricesAsync();
        Task<BasePrice> GetBasePriceByIdAsync(Guid id);
        Task<BasePrice> GetBasePriceByOriginDestintionAsync(string destination, string origin, Guid classId);
        Task<BasePrice> AddAsync(BasePrice basePrice);
        Task<BasePrice> UpdateAsync(BasePrice basePrice);
        Task RemoveAsync(Guid id);

    }
}
