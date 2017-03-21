using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.EntityFramework.Repository
{
    public interface IEfDbContextProvider
    {
        TDbContext Get<TDbContext>() where TDbContext : NamedDbContext;
    }
}
