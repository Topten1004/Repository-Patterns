using System.Collections.Generic;
using ProjectTemplate.Domain.Models.Base;
using ProjectTemplate.Domain.Models.Events;
using ProjectTemplate.Domain.Validation;

namespace ProjectTemplate.Domain.Models.Aggregates
{
    public class ProjectAggregate : AggregateRoot
    {
        private readonly HashSet<int> _numbers;
        private int _number;

        public ProjectAggregate(int number)
            : this()
        {
            Number = number;
        }

        protected ProjectAggregate()
            : base(() => new ProjectAggregateValidator())
        {
            _numbers = new HashSet<int>();
        }

        public IReadOnlyCollection<int> Numbers => _numbers;

        public int Number
        {
            get => _number;
            private set
            {
                _number = value;
                ValidateProperty(nameof(Number));
            }
        }


        public Test SomeEnterpriseBusinessLogic()
        {
            // Here you define enterprise specific business logic and apply checks with conditionals here. You throw exceptions here
            // when certain validations occur. (Yes, even if you have validators specific for each entity invoked at instantiation)
            // You add domain events here specific to the business rule(method).
            // This method is usually called by the CommandHandler at the Handle method, when using CQRS + MediatR.

            _numbers.Add(0);
            AddDomainEvent(new TestDomainEvent(0, this));

            // Here you usually return what the domain business model is for, for example, if you verify a payment here, you 
            // would create the payment and after adding it to the collection and create and add the domain event, you return
            // the object.
            return new Test();
        }
    }
}
