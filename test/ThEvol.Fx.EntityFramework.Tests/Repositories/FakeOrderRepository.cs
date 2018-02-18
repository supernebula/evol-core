using Evol.Fx.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;

namespace Evol.Fx.EntityFramework.Repository.Test.Repositories
{
    public class FakeOrderRepository : BaseEntityFrameworkRepository<FakeOrder, FakeEcDbContext>
    {
        public FakeOrderRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
