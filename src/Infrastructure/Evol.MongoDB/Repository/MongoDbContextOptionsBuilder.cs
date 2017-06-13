using System;

namespace Evol.MongoDB.Repository
{

    public class MongoDbContextOptionsBuilder<DbContext>
    {
        public Type DbContextType { get; set; }

        public string ConnectionString { get; set; }

        public MongoDbContextOptions<DbContext> Build()
        {
            return new MongoDbContextOptions<DbContext>()
            {
                ConnectionString = ConnectionString,
                DbContextType = DbContextType
            };
        }
    }

    public static class MongoDbContextOptionsBuilderExtensions
    {
        public static MongoDbContextOptionsBuilder<DbContext> UseConnectionString<DbContext>(this MongoDbContextOptionsBuilder<DbContext> builder, string connectionString)
        {
            builder.ConnectionString = connectionString;
            return builder;
        }
    }
}
