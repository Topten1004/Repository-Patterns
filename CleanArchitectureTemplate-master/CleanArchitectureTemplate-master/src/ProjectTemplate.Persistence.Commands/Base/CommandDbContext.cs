using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Persistence.Commands.Interfaces;

namespace ProjectTemplate.Persistence.Commands.Base
{
    //TO DO -> SaveChanges
    public abstract class CommandDbContext : DbContext
    {
        private readonly IMediator _mediator;
        private ITransaction _currentTransaction;

        public CommandDbContext(DbContextOptions options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task BeginTransactionAsync()
        {
            if (HasActiveTransaction)
            {
                throw new Exception("There is active transaction that has not finished.");
            }

            _currentTransaction = new EfTransaction(await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted));
        }

        public async Task RollbackTransactionAsync()
        {
            if (HasActiveTransaction)
            {
                try
                {
                    await _currentTransaction.RollbackAsync();
                }
                finally
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task CommitAsync()
        {
            if (HasActiveTransaction == false)
            {
                throw new InvalidOperationException("Not current transaction.");
            }

            try
            {
                await SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                await _currentTransaction.RollbackAsync();
                throw;
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
