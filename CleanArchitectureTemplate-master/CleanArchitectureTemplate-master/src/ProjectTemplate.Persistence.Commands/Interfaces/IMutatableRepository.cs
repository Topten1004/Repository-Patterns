using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectTemplate.Domain.Interfaces;
using ProjectTemplate.Persistence.Queries.Interfaces;

namespace ProjectTemplate.Persistence.Commands.Interfaces
{
    public interface IMutatableRepository<TEntity> : IReadableRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
