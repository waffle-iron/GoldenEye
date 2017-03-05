using System;
using System.Collections.Generic;
using System.Linq;
using GoldenEye.Backend.Core.Context.SaveChangesHandlers;
using GoldenEye.Backend.Core.Context.SaveChangesHandlers.Base;
using GoldenEye.Backend.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace GoldenEye.Backend.Core.Context
{
    public abstract class DataContext<T> : DbContext, IDataContext where T : DbContext
    {
        readonly IEnumerable<ISaveChangesHandler> _saveHandlers;

        protected DataContext()
        {
            SetInitializer();
        }

        protected DataContext(DbContextOptions<T> options) : base(options)
        {
            
        }

        protected virtual void SetInitializer()
        {
            Database.EnsureCreated();

        }

        public new void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public override int SaveChanges()
        {
            SaveChangesProcessor.Instance.RunAll(this);
            return base.SaveChanges();
        }

        public IEnumerable<IEntity> GetAddedEntities()
        {
            return ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity).OfType<IEntity>();
        }

        public IEnumerable<IEntity> GetUpdatedEntities()
        {
            return ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity).OfType<IEntity>();
        }
    }
}