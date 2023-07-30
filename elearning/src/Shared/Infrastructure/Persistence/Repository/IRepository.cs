using System;
using System.Collections.Generic;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Query.Criteria;

namespace elearning.src.Shared.Infrastructure.Persistence.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity Get(UUID id);
        List<TEntity> Find(Criteria criteria);
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
