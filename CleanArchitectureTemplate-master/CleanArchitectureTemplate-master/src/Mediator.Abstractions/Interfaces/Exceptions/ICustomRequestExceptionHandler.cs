using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Abstractions.Models;

namespace Mediator.Abstractions.Interfaces.Exceptions
{
    public interface ICustomRequestExceptionHandler<in TRequest, TResponse, in TException>
        where TException : Exception
    {
        Task Handle(TRequest request, TException exception, CustomRequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken);
    }

    public interface ICustomRequestExceptionHandler<in TRequest, TResponse> : ICustomRequestExceptionHandler<TRequest, TResponse, Exception>
    {
    }
}
