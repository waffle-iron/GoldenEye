﻿
using GoldenEye.Backend.Business.Entities;
using GoldenEye.Backend.Core.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GoldenEye.Backend.Business.Context
{
    public class SampleContext: DataContext<SampleContext>, ISampleContext
    {
        public SampleContext()
            //: base("name=DBConnectionString")
        {
        }

        public SampleContext(IConnectionProvider connectionProvider)
            //: base(connectionProvider)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TaskEntity>()
        //        .ToTable("Tasks")
        //        .HasKey(o => o.Id);

        //}
    }
}