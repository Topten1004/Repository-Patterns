using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjectTemplate.Domain.Models.Base;

namespace ProjectTemplate.Domain.Validation
{
    public abstract class DomainValidator<TModel> : AbstractValidator<TModel>
        where TModel : Entity
    {
        public DomainValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
