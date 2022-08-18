using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Practice.Api.Declarations.Queryable;
using Practice.Api.Database;

namespace Practice.Api.Implementations.Queryable
{
    public abstract class EntitySet<T> : IEntitySet<T> where T : class, IEntity
    {
        // don't remove if only u don't want 
        // unit tests to run properly, 
        // (used for mocking purposes)
        protected EntitySet()
        {
        }

        protected EntitySet(PracticeApiContext context) => Context = context;

        private PracticeApiContext Context { get; }

        public virtual IQueryable<T> Query() => Set;

        protected DbSet<T> Set => Context.Set<T>();

        public virtual void Add(T entity) => Set.Add(entity);

        public void AddRange(IEnumerable<T> entity) => Set.AddRange(entity);

        public void Update(T entity) => Context.Entry(entity).State = EntityState.Modified;

        public EntityEntry<T> Entry(T entity) => Context.Entry(entity);

        public EntityEntry<T> Attach(T entity) => Set.Attach(entity);

        public virtual void Remove(T entity) => Set.Remove(entity);

        public virtual void RemoveRange(IEnumerable<T> entities) => Set.RemoveRange(entities);

        public virtual async Task LoadCollectionAsync<TProperty>(T entity,
            Expression<Func<T, IEnumerable<TProperty>>> propertyExpression) where TProperty : class
        {
            await Context.Entry(entity).Collection(propertyExpression).LoadAsync();
        }

        public virtual async Task LoadReferenceAsync<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression)
            where TProperty : class
        {
            await Context.Entry(entity).Reference(propertyExpression).LoadAsync();
        }
    }
}
