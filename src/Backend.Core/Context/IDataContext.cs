using System;
using System.Collections.Generic;
using GoldenEye.Backend.Core.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GoldenEye.Backend.Core.Context
{
    public interface IDataContext : IDisposable
    {
        EntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        IEnumerable<IEntity> GetAddedEntities();
        IEnumerable<IEntity> GetUpdatedEntities();
    }
}
