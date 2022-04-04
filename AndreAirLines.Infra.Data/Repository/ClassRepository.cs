using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Repository.Base;
using AndreAirLines.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AndreAirLines.Infra.Data.Repository
{
    public class ClassRepository : BaseRepository<Class, AndreAirLinesAPIContext>, IClassRepository
    {
        public ClassRepository(AndreAirLinesAPIContext db) : base(db)
        {
        }

        public override Task<IQueryable<Class>> GetAllAsync(params Expression<Func<Class, object>>[] includeProperties)
        {
            return Task.Run(() => DbSet.FromSqlRaw("SELECT * from Class"));
        }
    }
}
