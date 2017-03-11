using Evol.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Evol.MongoDB.Repository
{
    public class BaseQueryEntry<T, TMongoDbContext> where TMongoDbContext : NamedMongoDbContext, new() where T : IEntity<string>
    {
        public BaseMongoDbRepository<T, TMongoDbContext> MongoDbRepository { get; set; }

        public virtual async Task<T> FindAsync(string id)
        {
            return await MongoDbRepository.FindAsync(id);
        }

        public virtual async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await MongoDbRepository.FindOneAsync(predicate);
        }

        public virtual async Task<List<T>> SelectAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderByKeySelector, bool isDescending = true)
        {
            return await MongoDbRepository.SelectAsync(predicate, orderByKeySelector, isDescending);
        }

        public virtual async Task<IPaged<T>> PagedSelectAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            return await MongoDbRepository.PagedSelectAsync(predicate, pageIndex, pageSize);
        }
    }
}
