using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using ProjectTemplate.Domain.Exceptions;

namespace ProjectTemplate.Domain.Models.Base
{
    public abstract class Validatable
    {
        private readonly Func<IValidator> _validatorFactory;

        protected Validatable(Func<IValidator> validatorFactory)
        {
            _validatorFactory = validatorFactory ?? throw new ArgumentException(nameof(validatorFactory));
        }

        protected void Validate()
        {
            var validator = _validatorFactory.Invoke();
            var result = validator.Validate(this);

            ProcessValidationResult(result);
        }

        protected void ValidateProperty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            var context = new ValidationContext<Validatable>(
                this, new PropertyChain(), new MemberNameValidatorSelector(new[] { name }));
            var validator = _validatorFactory.Invoke();
            var result = validator.Validate(context);

            ProcessValidationResult(result);
        }

        private void ProcessValidationResult(ValidationResult result)
        {
            if (result.IsValid == false)
            {
                var error = result.Errors.FirstOrDefault();
                throw new ValidationDomainException(error.ErrorMessage, error.ErrorMessage);
            }
        }
    }
}
