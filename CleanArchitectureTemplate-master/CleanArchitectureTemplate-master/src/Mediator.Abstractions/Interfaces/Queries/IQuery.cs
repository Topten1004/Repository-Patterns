using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Mediator.Abstractions.Interfaces.Queries
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
