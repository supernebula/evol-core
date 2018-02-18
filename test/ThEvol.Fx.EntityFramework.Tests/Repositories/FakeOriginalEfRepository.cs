using Evol.Fx.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;

namespace Evol.Fx.EntityFramework.Repository.Test.Repositories
{
    public class FakeArticleOriginalEfRepository : OriginalEntityFrameworkRepository<FakeArticle, FakeEcDbContext>
    {
        public FakeArticleOriginalEfRepository() : this(null)
        {
        }

        public FakeArticleOriginalEfRepository(FakeEcDbContext dbContext) : base(dbContext)
        {
        }
    }
}
