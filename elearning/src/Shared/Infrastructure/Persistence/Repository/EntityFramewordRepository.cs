﻿using System;
using System.Linq;
using elearning.src.Shared.Infrastructure.Helper;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using elearning.src.Shared.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.Shared.Infrastructure.Persistence.Repository
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ELearningContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IServiceScopeFactory ScopeFactory;

        public EntityFrameworkRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
            ScopeFactory = scopeFactory;
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity Get(UUID id)
        {
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ELearningContext>();
                IQueryable<TEntity> query = dbContext.Set<TEntity>();

                return query.FirstOrDefault<TEntity>(x => (Reflection.GetObjectProperty(Reflection.GetObjectProperty(x, "Id"), "Value")).ToString() == id.Value);
            }
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            //Db.Dispose();
            //GC.SuppressFinalize(this);
        }

        public virtual void Save(TEntity obj)
        {
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ELearningContext>();
                dbContext.Add(obj);
                dbContext.SaveChanges();
            }
        }
    }
}
