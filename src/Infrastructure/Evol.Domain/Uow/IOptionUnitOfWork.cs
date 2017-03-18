using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{
    public interface IOptionUnitOfWork
    {
        UnitOfWorkOption Option { get; }
    }
}
