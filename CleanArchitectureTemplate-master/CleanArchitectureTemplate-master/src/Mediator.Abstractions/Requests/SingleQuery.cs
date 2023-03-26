using System;
using System.Collections.Generic;
using System.Text;
using Mediator.Abstractions.Interfaces.Queries;

namespace Mediator.Abstractions.Requests
{
    public class SingleQuery<T> : ISingleQuery<T>
    {
        public string Id { get; set; }
    }
}
