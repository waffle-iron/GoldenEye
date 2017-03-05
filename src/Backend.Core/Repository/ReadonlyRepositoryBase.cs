using System.Linq;
using GoldenEye.Backend.Core.Context;
using GoldenEye.Backend.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace GoldenEye.Backend.Core.Repository
{
    public abstract class ReadonlyRepositoryBase<TEntity> : IReadonlyRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IDataContext Context;

        protected readonly IQueryable<TEntity> Queryable;

        protected bool Disposed;

        protected ReadonlyRepositoryBase(IDataContext context, IQueryable<TEntity> queryable)
        {
            Context = context;
            Queryable = queryable;
        }

        public virtual IQueryable<TEntity> Includes(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        public virtual TEntity GetById(object id, bool withNoTracking = true)
        {
            return Includes(withNoTracking ? Queryable.AsNoTracking() : Queryable).SingleOrDefault(r => r.Id == (int)id);

        }

        public virtual IQueryable<TEntity> GetAll(bool withNoTracking = true)
        {
            return Includes(withNoTracking ? Queryable.AsNoTracking() : Queryable);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }
            if (disposing)
            {
                Context.Dispose();
            }
            Disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }
    }
}