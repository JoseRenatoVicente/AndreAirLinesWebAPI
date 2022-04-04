using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;

namespace AndreAirLines.Infra.Data.Repository
{
    public class AircraftRepository : BaseRepository<Aircraft, AndreAirLinesAPIContext>, IAircraftRepository
    {
        public AircraftRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }
    }
}
