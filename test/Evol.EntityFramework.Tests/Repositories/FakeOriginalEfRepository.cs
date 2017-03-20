using Evol.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;

namespace Evol.EntityFramework.Repository.Test.Repositories
{
    public class FakeArticleOriginalEfRepository : OriginalEntityFrameworkRepository<FakeArticle, FakeEcDbContext>
    {
        public FakeArticleOriginalEfRepository(FakeEcDbContext dbContext) : base(dbContext)
        {
        }
    }
}
