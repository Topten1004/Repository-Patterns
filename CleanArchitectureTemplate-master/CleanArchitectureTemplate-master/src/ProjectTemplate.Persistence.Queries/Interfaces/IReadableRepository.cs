using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Persistence.Queries.Interfaces
{
    public interface IReadableRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> spec);

        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec);

        Task<TEntity> LastOrDefaultAsync(ISpecification<TEntity> spec);

        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecification<TEntity> spec);

        Task<bool> AnyAsync(ISpecification<TEntity> spec);
    }
}
