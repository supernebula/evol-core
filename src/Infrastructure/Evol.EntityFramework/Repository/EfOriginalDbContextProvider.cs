using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.EntityFramework.Repository
{
    public class EfOriginalDbContextProvider : IEfDbContextProvider
    {
        public EfOriginalDbContextProvider()
        {

        }
        public TDbContext Get<TDbContext>() where TDbContext : NamedDbContext
        {
            throw new NotImplementedException();
        }
    }
}
