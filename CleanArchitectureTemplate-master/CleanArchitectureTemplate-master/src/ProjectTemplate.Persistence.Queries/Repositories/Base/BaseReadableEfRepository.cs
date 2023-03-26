using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Persistence.Queries.Interfaces;

namespace ProjectTemplate.Persistence.Queries.Repositories.Base
{
    public abstract class BaseReadableEfRepository<TEntity> : IReadableRepository<TEntity>
         where TEntity : class
    {
        protected readonly DbContext _readableDbContext;
        private readonly ISpecificationEvaluationService<TEntity> _specificationEvaluationService;
        public BaseReadableEfRepository(
            DbContext readableDbContext,
            ISpecificationEvaluationService<TEntity> specificationEvaluationService)
        {
            _readableDbContext = readableDbContext;
            _specificationEvaluationService = specificationEvaluationService;
        }

        public async Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).SingleOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<TEntity> LastOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).LastOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _readableDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<bool> AnyAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).AnyAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return _specificationEvaluationService
                .GetQuery(_readableDbContext.Set<TEntity>()
                .AsQueryable(), spec);
        }
    }
}
