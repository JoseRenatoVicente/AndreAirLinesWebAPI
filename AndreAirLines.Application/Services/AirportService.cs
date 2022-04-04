using AndreAirLines.Application.Services.Interfaces;
using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirLines.Application.Services
{
    public class AirportService : IAirportService
    {
        private readonly ViaCepService _viaCepService;
        private readonly IAirportRepository _airportRepository;

        public AirportService(ViaCepService viaCepService, IAirportRepository airportRepository)
        {
            _viaCepService = viaCepService;
            _airportRepository = airportRepository;
        }

        public async Task<IEnumerable<Airport>> GetAirportsAsync()
        {
            return await _airportRepository.GetAllAsync();
        }

        public async Task<Airport> GetAirportByAcronymAsync(string acronym)
        {
            return (await _airportRepository.GetAllAsync(c => c.Address))
                .Where(c => c.Acronym == acronym).FirstOrDefault();
        }

        public async Task<Airport> AddAsync(Airport airport)
        {
            var address = await _viaCepService.ConsultarCEP(airport.Address.CEP);
            if (address is not null) airport.Address = address;

            await _airportRepository.AddAsync(airport);
            return airport;
        }

        public async Task<Airport> UpdateAsync(Airport airport)
        {
            await _airportRepository.UpdateAsync(airport);
            return airport;
        }

        public async Task RemoveAsync(string acronym)
        {
            await _airportRepository.RemoveAsync(await _airportRepository.FindAsync(c => c.Acronym == acronym));
        }
    }
}
