using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectTemplate.Application.Commands.Interfaces;
using ProjectTemplate.Domain.Models.Aggregates;
using ProjectTemplate.Persistence.Commands;
using ProjectTemplate.Persistence.Commands.Interfaces;

namespace ProjectTemplate.Persistence
{
    internal class ProjectAggregateUnitOfWork : IProjectAggregateUnitOfWork
    {
        private readonly ProjectAggregateCommandContext _dbContext;

        public ProjectAggregateUnitOfWork(
            ProjectAggregateCommandContext dbContext,
            IMutatableRepository<ProjectAggregate> projectAggregates)
        {
            ProjectAggregates = projectAggregates;
            _dbContext = dbContext;
        }

        public bool HasActiveTransaction => _dbContext.HasActiveTransaction;

        public IMutatableRepository<ProjectAggregate> ProjectAggregates { get; }

        public async Task BeginTransactionAsync()
        {
            await _dbContext.BeginTransactionAsync();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _dbContext.RollbackTransactionAsync();
        }
    }
}
