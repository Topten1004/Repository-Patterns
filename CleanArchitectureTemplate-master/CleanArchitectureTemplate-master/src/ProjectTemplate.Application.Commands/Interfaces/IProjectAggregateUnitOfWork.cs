using System;
using System.Collections.Generic;
using System.Text;
using ProjectTemplate.Domain.Models.Aggregates;
using ProjectTemplate.Persistence.Commands.Interfaces;

namespace ProjectTemplate.Application.Commands.Interfaces
{
    public interface IProjectAggregateUnitOfWork : IDataUnitOfWork
    {
        IMutatableRepository<ProjectAggregate> ProjectAggregates { get; }
    }
}
