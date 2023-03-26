using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Domain.Models.Aggregates;
using ProjectTemplate.Persistence.Commands.Base;

namespace ProjectTemplate.Persistence.Commands
{
    public class ProjectAggregateCommandContext : CommandDbContext
    {
        public ProjectAggregateCommandContext(DbContextOptions options, IMediator mediator)
            : base(options, mediator)
        {

        }

        public DbSet<ProjectAggregate> ProjectAggregates { get; set; }

        // More work to be done
    }
}
