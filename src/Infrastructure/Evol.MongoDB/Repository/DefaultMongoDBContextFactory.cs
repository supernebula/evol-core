using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.MongoDB.Repository
{
    public class DefaultMongoDbContextFactory : IMongoDbContextFactory
    {
        private readonly ConcurrentDictionary<Type, NamedMongoDbContext> _contextDic = new ConcurrentDictionary<Type, NamedMongoDbContext>();

        public NamedMongoDbContext Get<TDbContext>() where TDbContext : NamedMongoDbContext, new()
        {
            var typeKey = typeof(TDbContext);
            NamedMongoDbContext dbContext = null;
            if (_contextDic.ContainsKey(typeKey))
                _contextDic.TryGetValue(typeKey, out dbContext);
            if (dbContext == null)
                _contextDic.TryRemove(typeKey, out dbContext);
            else
                return dbContext;

            dbContext = new TDbContext();
            _contextDic.TryAdd(typeKey, dbContext);
            return dbContext;
        }
    }
}
