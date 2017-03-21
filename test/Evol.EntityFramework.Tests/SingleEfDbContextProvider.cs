using Evol.EntityFramework.Repository;
using System;

namespace Evol.EntityFramework.Tests
{
    public class SingleEfDbContextProvider : IEfDbContextProvider
    {
        private NamedDbContext context;
        public TDbContext Get<TDbContext>() where TDbContext : NamedDbContext
        {
            if(context == null)
                context = Activator.CreateInstance<TDbContext>();
            return (TDbContext)context;
        }
    }
}
