using Evol.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace Evol.EntityFramework.Tests
{
    public class SingleEfDbContextProvider : IEfDbContextProvider
    {
        private DbContext context;
        public TDbContext Get<TDbContext>() where TDbContext : DbContext, INamedDbContext
        {
            if(context == null)
                context = Activator.CreateInstance<TDbContext>();
            return (TDbContext)context;
        }
    }
}
