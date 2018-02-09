using Evol.Fx.EntityFramework.Repository;
using System.Data.Entity;
using Evol.Common.IoC;
using System;

namespace Evol.Fx.EntityFramework.Uow
{
    public class EfDbContextProvider : IEfDbContextProvider
    {
        private IIoCManager _ioCManager;

        public EfDbContextProvider(IIoCManager ioCManager)
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
