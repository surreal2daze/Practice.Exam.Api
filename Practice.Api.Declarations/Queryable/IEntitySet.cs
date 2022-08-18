using Microsoft.EntityFrameworkCore.ChangeTracking;
using Practice.Api.Database;
using System.Linq.Expressions;

namespace Practice.Api.Declarations.Queryable
{
    public interface IEntitySet<T> where T : class, IEntity
    {
        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        void Update(T entity);

        EntityEntry<T> Entry(T entity);

        EntityEntry<T> Attach(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task LoadCollectionAsync<TProperty>(T entity,
            Expression<Func<T, IEnumerable<TProperty>>> propertyExpression) where TProperty : class;

        Task LoadReferenceAsync<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression)
            where TProperty : class;
    }
}