using Microsoft.EntityFrameworkCore;
using System;

namespace Evol.EntityFramework.Repository.Test.Core
{

    public class FakeEfDbContextProvider : IEfDbContextProvider
    {
        private NamedDbContext context;

        public TDbContext Get<TDbContext>() where TDbContext : NamedDbContext
        {
            if (context == null)
                context = Activator.CreateInstance<TDbContext>();
            return (TDbContext)context;
        }

    }
}
