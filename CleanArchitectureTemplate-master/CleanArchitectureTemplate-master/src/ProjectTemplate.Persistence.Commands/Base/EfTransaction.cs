
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectTemplate.Persistence.Commands.Interfaces;

namespace ProjectTemplate.Persistence.Commands.Base
{
    public class EfTransaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EfTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
            Id = _transaction.TransactionId.ToString();
        }

        public string Id { get; }

        public Task CommitAsync()
        {
            return _transaction.CommitAsync();
        }

        public Task RollbackAsync()
        {
            return _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
