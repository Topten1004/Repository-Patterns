using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTemplate.Persistence.Queries.Interfaces
{
    public interface ISpecificationEvaluationService<T>
        where T : class
    {
        IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification);
    }
}
