using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AndreAirLines.Infra.Data.Repository.Base
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveAllAsync(Func<TEntity, bool> where);
        Task<bool> Exists(Func<TEntity, bool> where);
        Task SaveChangesAsync();
    }
}
