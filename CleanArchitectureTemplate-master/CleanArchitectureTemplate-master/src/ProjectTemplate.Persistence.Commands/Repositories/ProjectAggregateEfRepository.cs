using System;
using System.Collections.Generic;
using System.Text;
using ProjectTemplate.Domain.Interfaces;
using ProjectTemplate.Domain.Models.Base;
using ProjectTemplate.Persistence.Commands.Repositories.Base;

namespace ProjectTemplate.Persistence.Commands.Repositories
{
    public class ProjectAggregateEfRepository<TEntity> : BaseEfMutatableRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        public ProjectAggregateEfRepository(ProjectAggregateCommandContext dbContext)
            : base(dbContext)
        {

        }
    }
}
