using System;
using System.Data.Entity;

namespace Evol.Fx.EntityFramework.Repository.Test.Core
{

    public class FakeEfDbContextProvider : IEfDbContextProvider
    {
        private DbContext context;

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            if (context == null)
                context = Activator.CreateInstance<TDbContext>();
            return (TDbContext)context;
        }

    }
}
