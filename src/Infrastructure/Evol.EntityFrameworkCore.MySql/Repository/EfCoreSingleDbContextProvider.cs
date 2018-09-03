using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Evol.EntityFrameworkCore.MySql.Repository
{
    public class EfCoreSingleDbContextProvider : IEfCoreDbContextProvider
    {
        ConcurrentDictionary<string, DbContext> contextDic = new ConcurrentDictionary<string, DbContext>();

        public EfCoreSingleDbContextProvider(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
            var key = dbContext.GetType().FullName;
            contextDic.AddOrUpdate(key, dbContext, (k, v) => v);
        }

        public EfCoreSingleDbContextProvider(DbContext[] dbContexts)
        {
            if (dbContexts == null)
                throw new ArgumentNullException(nameof(dbContexts));
            if (dbContexts.Length == 0)
                throw new ArgumentOutOfRangeException("集合不包含任何元素");

            foreach (var item in dbContexts)
            {
                if (item == null) continue;
                
                contextDic.AddOrUpdate(item.GetType().FullName, item, (k, v) => v);
            }
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var key = typeof(TDbContext).FullName;
            DbContext dbContext;
            contextDic.TryGetValue(key, out dbContext);
            var value = dbContext as TDbContext;
            return value;
        }
    }
}
