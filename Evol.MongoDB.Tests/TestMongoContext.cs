using Evol.MongoDB.Repository;

namespace Evol.MongoDB.Test
{
    public class TestMongoContext : NamedMongoDbContext
    {
        public TestMongoContext() : base("testMongoContext")
        {
        }
    }
}
