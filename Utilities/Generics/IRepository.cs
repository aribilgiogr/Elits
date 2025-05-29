using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Utilities.Generics
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //CREATE
        Task CreateOneAsync(TEntity entity);
        Task CreateManyAsync(IEnumerable<TEntity> entities);

        //READ
        Task<TEntity?> FindOneByKeyAsync(object entityKey);
        Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
        Task<IEnumerable<TEntity>> FindManyWithOrderedAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool ascending = true, Expression<Func<TEntity, bool>>? expression = null);
        Task<IEnumerable<TEntity>> FindManyPagedAsync(int page, int pageSize, Expression<Func<TEntity, bool>>? expression = null);

        // Tam akış için tek sorumluluk ilkesine aykırı metot:
        Task<IEnumerable<TEntity>> FindAdvancedAsync<TKey>(
            Expression<Func<TEntity, bool>>? filter = null,
            Expression<Func<TEntity, TKey>>? orderBy = null,
            bool ascending = true,
            int? page = null,
            int? pageSize = null,
            params string[] includes
        );

        //UPDATE
        Task UpdateOneAsync(TEntity entity);
        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        //DELETE
        Task DeleteOneAsync(TEntity entity);
        Task DeleteOneAsync(object entityKey);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task DeleteManyAsync(IEnumerable<TEntity> entities);

        //EXTRAS
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<bool> ExistsAsync(object entityKey);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);

    }
}
