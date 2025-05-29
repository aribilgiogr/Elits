using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utilities.Generics
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression != null ? await _set.AnyAsync(expression) : await _set.AnyAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression != null ? await _set.CountAsync(expression) : await _set.CountAsync();
        }

        public virtual async Task CreateManyAsync(IEnumerable<TEntity> entities)
        {
            await _set.AddRangeAsync(entities);
        }

        public virtual async Task CreateOneAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public virtual async Task DeleteManyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            var entities = await FindManyAsync(expression);
            await DeleteManyAsync(entities);
        }

        public virtual async Task DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _set.RemoveRange(entities));
        }

        public virtual async Task DeleteOneAsync(TEntity entity)
        {
            await Task.Run(() => _set.Remove(entity));
        }

        public virtual async Task DeleteOneAsync(object entityKey)
        {
            var entity = await FindOneByKeyAsync(entityKey);
            if (entity != null)
            {
                await DeleteOneAsync(entity);
            }
        }

        public async Task<bool> ExistsAsync(object entityKey)
        {
            return await FindOneByKeyAsync(entityKey) != null;
        }

        public Task<IEnumerable<TEntity>> FindAdvancedAsync<TKey>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, TKey>>? orderBy = null, bool ascending = true, int? page = null, int? pageSize = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression != null ? await _set.FirstOrDefaultAsync(expression) : await _set.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
        {
            IQueryable<TEntity> entities = expression != null ? _set.Where(expression) : _set;

            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }

            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindManyPagedAsync(int page, int pageSize, Expression<Func<TEntity, bool>>? expression = null)
        {
            if (expression != null)
            {
                return await _set.Where(expression)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
            }
            else
            {
                return await _set.Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> FindManyWithOrderedAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool ascending = true, Expression<Func<TEntity, bool>>? expression = null)
        {
            IQueryable<TEntity> entities = expression != null ? _set.Where(expression) : _set;
            if (ascending)
            {
                return await entities.OrderBy(orderBy).ToListAsync();
            }
            else
            {
                return await entities.OrderByDescending(orderBy).ToListAsync();
            }
        }

        public virtual async Task<TEntity?> FindOneByKeyAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public virtual async Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _set.UpdateRange(entities));
        }

        public virtual async Task UpdateOneAsync(TEntity entity)
        {
            await Task.Run(() => _set.Update(entity));
        }
    }
}
