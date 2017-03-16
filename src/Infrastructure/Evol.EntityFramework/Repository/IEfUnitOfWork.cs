using Evol.Common.Uow;
using Evol.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.EntityFramework
{
    public interface IEfUnitOfWork : IUnitOfWork<NamedDbContext>
    {
    }
}
