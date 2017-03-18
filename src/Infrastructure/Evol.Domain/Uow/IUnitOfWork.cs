using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{

    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkToComplete
    {
        string Id { get; }

        IUnitOfWork Outer { get; set; }

        void Begin(UnitOfWorkOption option);
    }
}
