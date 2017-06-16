using Evol.MongoDB.Repository;
using System;

namespace Evol.TMovieLog.Data
{
    public class LogMongoContext : NamedMongoDbContext
    {
        public LogMongoContext() : base("testMongoContext")
        {
        }
    }
}
