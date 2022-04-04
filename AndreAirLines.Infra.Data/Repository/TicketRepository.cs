using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;

namespace AndreAirLines.Infra.Data.Repository
{
    public class TicketRepository : BaseRepository<Ticket, AndreAirLinesAPIContext>, ITicketRepository
    {
        public TicketRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }
    }
}
