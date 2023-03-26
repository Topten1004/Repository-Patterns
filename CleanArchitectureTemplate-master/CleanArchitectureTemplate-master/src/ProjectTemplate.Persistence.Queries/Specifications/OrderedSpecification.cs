using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ProjectTemplate.Persistence.Queries.Specifications.Enums;

namespace ProjectTemplate.Persistence.Queries.Specifications
{
    public class OrderedSpecification<T> : SpecificationDecorator<T>
        where T : class
    {
        public OrderedSpecification(BaseSpecification<T> spec)
            : base(spec)
        {

        }

        public virtual OrderedSpecification<T> ApplyThenOrderBy(
            Expression<Func<T, object>> orderByExpression)
        {
            _spec
                ._thenOrderBy
                .Add(new OrderBy<T>(OrderType.Asc, orderByExpression));

            return this;
        }

        public virtual OrderedSpecification<T> ApplyThenOrderByDescending(
            Expression<Func<T, object>> orderByDescendingExpression)
        {
            _spec
                ._thenOrderBy
                .Add(new OrderBy<T>(OrderType.Desc, orderByDescendingExpression));

            return this;
        }
    }
}
