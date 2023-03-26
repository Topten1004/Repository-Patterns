using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjectTemplate.Domain.Interfaces;

namespace ProjectTemplate.Domain.Models.Base
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        protected AggregateRoot(Func<IValidator> validatorFactory)
            : base(validatorFactory)
        {
        }

        protected AggregateRoot(Func<IValidator> validatorFactory, string id)
            : base(validatorFactory, id)
        {
        }
    }
}
