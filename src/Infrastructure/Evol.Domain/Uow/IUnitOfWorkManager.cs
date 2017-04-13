using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{
    public interface IActiveUnitOfWorkManager
    {
        IActiveUnitOfWork Current { get; }
    }

    public interface IUnitOfWorkManager : IActiveUnitOfWorkManager
    {
        IUnitOfWork Build();
    }
}
