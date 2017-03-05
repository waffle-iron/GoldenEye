using System.Collections.Generic;
using System.Linq;
using GoldenEye.Backend.Core.Context;
using GoldenEye.Backend.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace GoldenEye.Backend.Core.Repository
{
    public abstract class RepositoryBase<TEntity> : ReadonlyRepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> DbSet;
        
        protected RepositoryBase(IDataContext context, DbSet<TEntity> dbSet) : base(context, dbSet)
        {
            DbSet = dbSet;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return Add(entity, true);
        }

        private TEntity Add(TEntity entity, bool shouldSaveChanges)
        {
            var result = DbSet.Add(entity);

            if (shouldSaveChanges)
                SaveChanges();

            return result.Entity;
        }

        public virtual IQueryable<TEntity> AddAll(IEnumerable<TEntity> entities)
        {
            var result = entities.Select(entity => Add(entity, false)).ToList().AsQueryable();
            
            SaveChanges();

            return result;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var oldEntity = Context.Entry(entity);
            if (oldEntity.State != EntityState.Detached)
                return oldEntity.Entity;
            oldEntity.State = EntityState.Modified;
            SaveChanges();
            return DbSet.Attach(entity).Entity;
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public virtual bool Delete(int id)
        {
            return DbSet.Remove(GetById(id)) != null;
        }
    }
}