using System;
using elearning.src.Shared.Domain;

namespace elearning.src.Shared.Infrastructure.Persistence.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity Get(UUID id);
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
