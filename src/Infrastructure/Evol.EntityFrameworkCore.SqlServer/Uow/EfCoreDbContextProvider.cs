using Evol.EntityFrameworkCore.SqlServer.Repository;
using Microsoft.EntityFrameworkCore;
using Evol.Common.IoC;
using System;

namespace Evol.EntityFrameworkCore.SqlServer.Uow
{
    public class EfCoreDbContextProvider : IEfCoreDbContextProvider
    {
        private IIoCManager _ioCManager;

        public EfCoreDbContextProvider(IIoCManager ioCManager)
        {
            if (ioCManager == null)
                throw new ArgumentNullException(nameof(ioCManager));
            _ioCManager = ioCManager;
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var context = _ioCManager.GetService<TDbContext>();
            return context;
        }
    }
}
