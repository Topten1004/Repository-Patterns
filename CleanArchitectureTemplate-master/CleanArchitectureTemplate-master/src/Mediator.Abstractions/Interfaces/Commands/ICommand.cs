using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Mediator.Abstractions.Interfaces.Commands
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
