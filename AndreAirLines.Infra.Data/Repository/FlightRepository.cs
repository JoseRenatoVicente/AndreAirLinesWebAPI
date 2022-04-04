using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;

namespace AndreAirLines.Infra.Data.Repository
{
    public class FlightRepository : BaseRepository<Flight, AndreAirLinesAPIContext>, IFlightRepository
    {
        public FlightRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }
    }
}
