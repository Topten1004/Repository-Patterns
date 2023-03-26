using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ProjectTemplate.Persistence.Queries.Specifications.Enums;

namespace ProjectTemplate.Persistence.Queries.Specifications
{
    public class OrderBy<T>
        where T : class
    {
        public OrderBy(OrderType type, Expression<Func<T, object>> expression)
        {
            Type = type;
            Expression = expression;
        }

        public OrderType Type { get; }

        public Expression<Func<T, object>> Expression { get; }
    }
}
