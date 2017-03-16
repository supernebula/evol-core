using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{
    public interface ICurrentUnitOfWorkProvider
    {
        IUnitOfWork Current { get; set; }
    }
}
