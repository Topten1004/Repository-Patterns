using System;
using System.Threading.Tasks;

namespace ProjectTemplate.Persistence.Commands.Interfaces
{
    public interface ITransaction : IDisposable
    {
        string Id { get; }

        Task CommitAsync();

        Task RollbackAsync();
    }
}
