
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Persistence.Commands;
using ProjectTemplate.Persistence.Commands.Interfaces;
using ProjectTemplate.Persistence.Queries.Interfaces;
using ProjectTemplate.Persistence.Queries.Specifications.Services;
using ProjectTemplate.Persistence.Commands.Repositories;


namespace ProjectTemplate.Persistence
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterPersistenceDependencies(
            this IServiceCollection services, string tripsCommandDbConnectionString)
        {
            services.AddDbContext<ProjectAggregateCommandContext>(c => c.UseSqlServer(tripsCommandDbConnectionString));

            services.AddTransient(typeof(ISpecificationEvaluationService<>), typeof(SpecificationEvaluationService<>));
            services.AddTransient(typeof(IMutatableRepository<>), typeof(ProjectAggregateEfRepository<>));

            return services;
        }
    }
}
