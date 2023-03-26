using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjectTemplate.Domain.Models.Aggregates;

namespace ProjectTemplate.Domain.Validation
{
    public class ProjectAggregateValidator : DomainValidator<ProjectAggregate>
    {
        public ProjectAggregateValidator()
        {
            RuleFor(x => x.Number)
                .LessThanOrEqualTo(5);
        }
    }
}
