using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ProjectTemplate.Persistence.Queries.Specifications;

namespace ProjectTemplate.Persistence.Queries.Interfaces
{
    public interface ISpecification<T>
        where T : class
    {
        IReadOnlyCollection<Expression<Func<T, bool>>> Criterias { get; }

        IReadOnlyCollection<Expression<Func<T, object>>> Includes { get; }

        OrderBy<T> OrderBy { get; }

        IReadOnlyCollection<OrderBy<T>> ThenOrderBy { get; }
    }
}
