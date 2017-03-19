using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public interface IActiveUnitOfWork : IUnitOfWorkToComplete
    {
        UnitOfWorkOption Option { get; }

        Task SaveChangesAsync();

        bool IsDisposed { get; }
    }
}
