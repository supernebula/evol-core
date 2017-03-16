using System;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public interface IUnitOfWorkToComplete : IDisposable
    {
        void Complete();

        Task CompleteAsync();
    }
}
