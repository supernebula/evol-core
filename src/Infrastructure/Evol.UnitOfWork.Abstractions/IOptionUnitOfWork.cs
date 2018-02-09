using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.UnitOfWork.Abstractions
{
    public interface IOptionUnitOfWork
    {
        UnitOfWorkOption Option { get; }
    }
}
