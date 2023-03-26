using System;
using System.Collections.Generic;
using System.Text;
using Mediator.Abstractions.Interfaces.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Commands.Features.TestFeature;
using ProjectTemplate.Domain.Models.Aggregates;

namespace ProjectTemplate.Application.Commands
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterProjectAggregateApplicationCommandsDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomRequestExceptionHandler<TestCommand, ProjectAggregate, TestCommandException>, TestCommandExceptionHandler>();

            return services;
        }
    }
}
