using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Abstractions.Interfaces.Exceptions;
using Mediator.Abstractions.Models;
using ProjectTemplate.Domain.Models.Aggregates;

namespace ProjectTemplate.Application.Commands.Features.TestFeature
{
    public class TestCommandExceptionHandler : ICustomRequestExceptionHandler<TestCommand, ProjectAggregate, TestCommandException>
    {
        public async Task Handle(
            TestCommand request,
            TestCommandException exception,
            CustomRequestExceptionHandlerState<ProjectAggregate> state,
            CancellationToken cancellationToken)
        {
            state.SetHandled();
        }
    }
}
