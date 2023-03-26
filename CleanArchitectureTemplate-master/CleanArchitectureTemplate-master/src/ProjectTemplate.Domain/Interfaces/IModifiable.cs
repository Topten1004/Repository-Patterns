using System;


namespace ProjectTemplate.Domain.Interfaces
{
    public interface IModifiable
    {
        DateTime? ModifiedOn { get; }
    }
}
