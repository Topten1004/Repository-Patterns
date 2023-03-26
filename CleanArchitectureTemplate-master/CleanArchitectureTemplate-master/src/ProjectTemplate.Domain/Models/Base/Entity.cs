using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProjectTemplate.Domain.Interfaces;

namespace ProjectTemplate.Domain.Models.Base
{
    public abstract class Entity : Validatable, IEntity
    {
        private HashSet<IDomainEvent> _domainEvents;
        private string _id;

        protected Entity(Func<IValidator> validatorFactory, string id)
            : this(validatorFactory)
        {
            Id = id;
        }

        protected Entity(Func<IValidator> validatorFactory)
            : base(validatorFactory)
        {
            _domainEvents = new HashSet<IDomainEvent>();
        }

        public string Id
        {
            get => _id;
            private set
            {
                _id = value;
                ValidateProperty(nameof(Id));
            }
        }

        public DateTime CreatedOn { get; protected set; }

        public DateTime? ModifiedOn { get; protected set; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected IDomainEvent AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
            return @event;
        }

        public async Task InvokeEvents(Func<IDomainEvent, Task> invoke)
        {
            var domainEvents = _domainEvents;
            _domainEvents = null;

            var tasks = domainEvents?
                .Select(x => Task.Run(async () => await invoke(x)));

            if (tasks != null)
            {
                await Task.WhenAll(tasks);
            }
        }
    }
}
