using Evol.Fx.EntityFramework.Repository;
using System.Data.Entity;
using System;

namespace Evol.Fx.EntityFramework.Tests
{
    public class SingleEfDbContextProvider : IEfDbContextProvider
    {
        private DbContext context;
        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            if(context == null)
                context = Activator.CreateInstance<TDbContext>();
            return (TDbContext)context;
        }
    }
}
