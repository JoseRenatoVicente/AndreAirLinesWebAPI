using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;

namespace AndreAirLines.Infra.Data.Repository
{
    public class PassengerRepository : BaseRepository<Passenger, AndreAirLinesAPIContext>, IPassengerRepository
    {
        public PassengerRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }
    }

}
