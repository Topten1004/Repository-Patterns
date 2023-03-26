using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ProjectTemplate.Persistence.Queries.Interfaces;
using ProjectTemplate.Persistence.Queries.Specifications.Enums;

namespace ProjectTemplate.Persistence.Queries.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
        where T : class
    {
        private readonly List<Expression<Func<T, object>>> _includes;
        private readonly List<Expression<Func<T, bool>>> _criterias;
        internal readonly List<OrderBy<T>> _thenOrderBy;

        public BaseSpecification()
        {
            _includes = new List<Expression<Func<T, object>>>();
            _criterias = new List<Expression<Func<T, bool>>>();
            _thenOrderBy = new List<OrderBy<T>>();
        }

        public virtual IReadOnlyCollection<Expression<Func<T, object>>> Includes => _includes;

        public virtual IReadOnlyCollection<Expression<Func<T, bool>>> Criterias => _criterias;

        public virtual OrderBy<T> OrderBy { get; private set; }

        public virtual IReadOnlyCollection<OrderBy<T>> ThenOrderBy => _thenOrderBy;

        public virtual BaseSpecification<T> AddInclude(
            Expression<Func<T, object>> includeExpression)
        {
            _includes.Add(includeExpression);
            return this;
        }

        public virtual BaseSpecification<T> AddCriteria(
            Expression<Func<T, bool>> criteria)
        {
            _criterias.Add(criteria);
            return this;
        }

        public virtual OrderedSpecification<T> ApplyOrderBy(
            Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = new OrderBy<T>(OrderType.Asc, orderByExpression);
            return new OrderedSpecification<T>(this);
        }

        public virtual OrderedSpecification<T> ApplyOrderByDescending(
            Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderBy = new OrderBy<T>(OrderType.Desc, orderByDescendingExpression);
            return new OrderedSpecification<T>(this);
        }
    }
}
