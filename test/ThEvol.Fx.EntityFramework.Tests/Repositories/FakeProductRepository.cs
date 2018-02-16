using Evol.Fx.EntityFramework.Repository.Test.Core;
using Evol.Tests.Models;


namespace Evol.Fx.EntityFramework.Repository.Test.Repositories
{
    public class FakeProductRepository : BaseEntityFrameworkRepository<FakeProduct, FakeEcDbContext>
    {
        public FakeProductRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
