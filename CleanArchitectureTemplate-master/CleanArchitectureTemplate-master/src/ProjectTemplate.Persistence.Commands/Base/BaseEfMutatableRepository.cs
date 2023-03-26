using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Domain.Interfaces;
using ProjectTemplate.Persistence.Commands.Base;
using ProjectTemplate.Persistence.Commands.Interfaces;
using ProjectTemplate.Persistence.Queries.Repositories.Base;

namespace ProjectTemplate.Persistence.Commands.Repositories.Base
{
    public abstract class BaseEfMutatableRepository<TEntity>
        : BaseReadableEfRepository<TEntity>, IMutatableRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected readonly CommandDbContext _commandDbContext;

        public BaseEfMutatableRepository(CommandDbContext dbContext)
            : base(dbContext)
        {
            _commandDbContext = dbContext;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            _commandDbContext.Set<TEntity>().Add(entity);

            return Task.FromResult(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _commandDbContext.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _commandDbContext.Set<TEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
