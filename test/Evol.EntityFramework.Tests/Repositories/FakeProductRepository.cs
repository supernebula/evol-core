using Evol.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;


namespace Evol.EntityFramework.Repository.Test.Repositories
{
    public class FakeProductRepository : BaseEntityFrameworkRepository<FakeProduct, FakeEcDbContext>
    {
        public FakeProductRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
