using System.Configuration;
using MongoDB.Driver;
using Evol.Common;

namespace Evol.MongoDB.Repository
{
    public class NamedMongoDbContext : INamed
    {
        public string Name { get; set; }

        public IMongoClient MongoClient { get; private set; }

        public IMongoDatabase Database { get; private set; }

        protected NamedMongoDbContext(string connectionStringName)
        {
            Name = connectionStringName;
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            var mongoUrl = new MongoUrl(connectionString);
            MongoClient = new MongoClient(mongoUrl);
            Database = MongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
    }
}
