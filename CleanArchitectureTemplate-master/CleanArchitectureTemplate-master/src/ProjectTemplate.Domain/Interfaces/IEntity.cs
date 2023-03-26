using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces
{
    public interface IEntity : ICreatable, IModifiable
    {
        string Id { get; }

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        Task InvokeEvents(Func<IDomainEvent, Task> invoke);
    }
}
