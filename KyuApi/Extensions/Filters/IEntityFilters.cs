using System.Linq;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Extensions.Filters
{
    public static class IEntityFilters
    {
        public static TEntity FindById<TEntity, TKey>(this IQueryable<TEntity> source, TKey id) where TEntity: IEntity<TKey>
        {
            return source.FirstOrDefault(e => e.Id.Equals(id));
        }

        public static IQueryable<TEntity> ById<TEntity, TKey>(this IQueryable<TEntity> source, TKey id) where TEntity: IEntity<TKey>
        {
            return source.Where(e => e.Id.Equals(id));
        }
    }
}