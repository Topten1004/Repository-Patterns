using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator.Abstractions.Interfaces.Queries
{
    public interface ISingleQuery<out T> : IQuery<T>
    {
        string Id { get; }
    }
}
