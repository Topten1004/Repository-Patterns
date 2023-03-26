using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.Persistence.Commands.Interfaces
{
    public interface IDataUnitOfWork
    {
        bool HasActiveTransaction { get; }

        Task BeginTransactionAsync();

        Task RollbackTransactionAsync();

        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
