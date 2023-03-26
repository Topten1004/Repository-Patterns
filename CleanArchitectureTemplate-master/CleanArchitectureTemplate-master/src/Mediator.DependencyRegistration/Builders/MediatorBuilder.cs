using System;
using System.Reflection;
using Mediator.DependencyRegistration.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.DependencyRegistration.Builders
{
    public class MediatorBuilder : IMediatorBuilder
    {
        private readonly IServiceCollection _services;

        public MediatorBuilder(IServiceCollection services, params Assembly[] assemblies)
        {
            _services = services;

            RegisterMediator(assemblies);
        }

        public IMediatorBuilder WithPersistableBehavior()
        {
            throw new NotImplementedException();
            // Here you could register PersistableBehavior which contains a IDataUnitOfWork class
            // which you should define separately. It will be for maintaining all operations on 
            // different databases, like MSSQL, Postgre etc, in a single transaction
        }

        private void RegisterMediator(params Assembly[] assemblies)
        {
            _services.AddMediatR(assemblies);
        }
    }
}
