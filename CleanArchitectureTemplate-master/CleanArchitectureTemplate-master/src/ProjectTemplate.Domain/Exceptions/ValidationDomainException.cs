using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Domain.Exceptions
{
    public class ValidationDomainException : DomainException
    {
        public ValidationDomainException(string propertyName, string message)
            : base(message)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}
