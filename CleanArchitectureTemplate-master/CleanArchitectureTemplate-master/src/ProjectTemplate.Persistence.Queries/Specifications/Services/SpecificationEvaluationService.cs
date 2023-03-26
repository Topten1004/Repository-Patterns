using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Persistence.Queries.Interfaces;
using ProjectTemplate.Persistence.Queries.Specifications.Enums;

namespace ProjectTemplate.Persistence.Queries.Specifications.Services
{
    public class SpecificationEvaluationService<T> : ISpecificationEvaluationService<T>
        where T : class
    {
        public IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            query = specification.Criterias?.Aggregate(
                query, (current, criteria) => current.Where(criteria));

            query = specification.Includes.Aggregate(
                query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = ApplyOrderBy(query, specification);
            }

            return query;
        }

        private IQueryable<T> ApplyOrderBy(IQueryable<T> query, ISpecification<T> specification)
        {
            var order = specification.OrderBy;
            var expression = specification.OrderBy.Expression;

            var orderedQuery = order.Type.Equals(OrderType.Asc)
                     ? query.OrderBy(expression)
                     : query.OrderByDescending(expression);

            return ApplyThenOrderBy(orderedQuery, specification);
        }

        private IQueryable<T> ApplyThenOrderBy(IOrderedQueryable<T> orderedQuery, ISpecification<T> specification)
        {
            return specification.ThenOrderBy.Aggregate(
                orderedQuery,
                (current, orderBy) =>
                    orderBy.Type.Equals(OrderType.Asc)
                    ? current.ThenBy(orderBy.Expression)
                    : current.ThenByDescending(orderBy.Expression));
        }
    }
}
