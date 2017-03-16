using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public string Id { get; }
        public IUnitOfWork Outer { get; set; }

        public void Begin(UnitOfWorkOption option)
        {
            throw new NotImplementedException();
        }

        public UnitOfWorkBase()
        {

        }
    }
}
