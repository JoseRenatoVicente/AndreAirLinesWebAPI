using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;

namespace AndreAirLines.Infra.Data.Repository
{
    public class BasePriceRepository : BaseRepository<BasePrice, AndreAirLinesAPIContext>, IBasePriceRepository
    {
        public BasePriceRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }
    }
}
