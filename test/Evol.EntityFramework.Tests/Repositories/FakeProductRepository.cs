using Evol.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;


namespace Evol.EntityFramework.Repository.Test.Repositories
{
    public class FakeProductRepository : BasicEntityFrameworkRepository<FakeProduct, FakeEcDbContext>
    {
        public FakeProductRepository()
        { }
    }
}
