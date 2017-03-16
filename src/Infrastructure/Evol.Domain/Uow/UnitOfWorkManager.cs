using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        public IActiveUnitOfWork Current { get; }

        public IUnitOfWorkToComplete Begin()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWorkToComplete Begin(UnitOfWorkOption option)
        {
            throw new NotImplementedException();
        }
    }
}
