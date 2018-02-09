using System;
using Evol.Common.IoC;
using Evol.Dapper.Repository;

namespace Evol.Dapper.Uow
{

    public class DapperDbContextProvider : IDapperDbContextProvider
    {
        private IIoCManager _ioCManager;

        public DapperDbContextProvider(IIoCManager ioCManager)
        {
            if (ioCManager == null)
                throw new ArgumentNullException(nameof(_ioCManager));
        }

        public TDbContext Get<TDbContext>() where TDbContext : DapperDbContext
        {
            var context = _ioCManager.GetService<TDbContext>();
            return context;
        }
    }
}
