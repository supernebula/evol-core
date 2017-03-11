using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Evol.EntityFramework.Repository.Test.Core
{

    public class FakeEfDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        private TContext _context;
        public TContext Create()
        {
            return _context ?? (_context = Activator.CreateInstance<TContext>());
        }
    }
}
