using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public interface IActiveUnitOfWork : IOptionUnitOfWork
    {

        void Commit();

        Task CommitAsync();

        bool IsDisposed { get; }
    }
}
