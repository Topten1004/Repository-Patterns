using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectTemplate.Persistence.Queries.Specifications
{
    public class SpecificationDecorator<T> : BaseSpecification<T>
         where T : class
    {
        protected readonly BaseSpecification<T> _spec;

        public SpecificationDecorator(BaseSpecification<T> spec)
        {
            _spec = spec;
        }

        public override IReadOnlyCollection<Expression<Func<T, bool>>> Criterias => _spec.Criterias;

        public override IReadOnlyCollection<Expression<Func<T, object>>> Includes => _spec.Includes;

        public override OrderBy<T> OrderBy => _spec.OrderBy;

        public override IReadOnlyCollection<OrderBy<T>> ThenOrderBy => _spec.ThenOrderBy;

        public override BaseSpecification<T> AddCriteria(
            Expression<Func<T, bool>> criteria)
        {
            return _spec.AddCriteria(criteria);
        }

        public override BaseSpecification<T> AddInclude(
            Expression<Func<T, object>> includeExpression)
        {
            return _spec.AddInclude(includeExpression);
        }

        public override OrderedSpecification<T> ApplyOrderBy(
            Expression<Func<T, object>> orderByExpression)
        {
            return _spec.ApplyOrderBy(orderByExpression);
        }

        public override OrderedSpecification<T> ApplyOrderByDescending(
            Expression<Func<T, object>> orderByDescendingExpression)
        {
            return _spec.ApplyOrderByDescending(orderByDescendingExpression);
        }
    }
}
