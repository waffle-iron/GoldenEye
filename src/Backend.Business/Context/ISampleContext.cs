using GoldenEye.Backend.Business.Entities;
using GoldenEye.Backend.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace GoldenEye.Backend.Business.Context
{
    public interface ISampleContext: IDataContext
    {
        DbSet<TaskEntity> Tasks { get; }
    }
}