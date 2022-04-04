using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;

namespace AndreAirLines.Infra.Data.Repository
{
    public class AirportRepository : BaseRepository<Airport, AndreAirLinesAPIContext>, IAirportRepository
    {
        public AirportRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }
    }
}
