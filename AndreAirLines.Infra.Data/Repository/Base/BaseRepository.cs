using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AndreAirLines.Infra.Data.Repository.Base
{
    public abstract class BaseRepository<TEntity, Context> :
       IBaseRepository<TEntity> where TEntity : class
        where Context : DbContext
    {
        protected readonly Context Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(Context db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = DbSet.AsNoTracking();

            if (includeProperties.Any())
            {
                return await Include(DbSet, includeProperties);
            }

            return query;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.AsNoTracking().Where(where).ToListAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.Where(where).FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
            await SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities).ConfigureAwait(false);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task RemoveAllAsync(Func<TEntity, bool> where)
        {
            DbSet.RemoveRange(DbSet.ToList().Where(where));
            await SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se existe algum objeto com a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<bool> Exists(Func<TEntity, bool> where)
        {
            var iquerable = await GetAllAsync();
            return iquerable.Any(where);
        }

        public virtual async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private Task<IQueryable<TEntity>> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Task.Run(() =>
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }

                return query;

            });
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
