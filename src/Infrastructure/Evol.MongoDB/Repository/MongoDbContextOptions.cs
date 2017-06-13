using System;

namespace Evol.MongoDB.Repository
{
    public class MongoDbContextOptions
    {
        public Type DbContextType { get; set; }

        public string ConnectionString { get; set; }
    }

    public class MongoDbContextOptions<TDbContext> : MongoDbContextOptions
    {

    }
}
