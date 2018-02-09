using System;
using System.Threading.Tasks;

namespace Evol.UnitOfWork.Abstractions
{
    public interface IUnitOfWorkToComplete : IDisposable
    {
        Task CommitAsync();
    }
}
