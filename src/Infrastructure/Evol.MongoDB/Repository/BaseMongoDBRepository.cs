using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using System.Threading.Tasks;
using Evol.Common;
using Microsoft.Practices.Unity;
using MongoDB.Driver.Linq;

namespace Evol.MongoDB.Repository
{
    public class BaseMongoDbRepository<T, TMongoDbContext> where TMongoDbContext : NamedMongoDbContext, new() where T : IEntity<string> 
    {
        private NamedMongoDbContext MongoDbContext => MongoDbContextFactory.Get<TMongoDbContext>();

        protected IMongoDatabase Database => MongoDbContext.Database;

        private IMongoCollection<T> _collection;

        protected IMongoCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                {
                    var name = typeof(T).Name.ToLower();
                    _collection = Database.GetCollection<T>(name);
                }
                return _collection; 
            }
        }

        [Dependency]
        public IMongoDbContextFactory MongoDbContextFactory { get; set; }

        protected BaseMongoDbRepository()
        {
        }

        protected BaseMongoDbRepository(IMongoDbContextFactory mongoDbContextFactory)
        {
            MongoDbContextFactory = mongoDbContextFactory;
        }

        /// <summary>
        /// 根据Id, 返回单个文档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync(string id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id));
            return await Collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据条件，返回单个文档
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<T> FindOneAsync(FilterDefinition<T> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据条件，返回单个文档
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return await Collection.AsQueryable().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 返回查询源
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> AsQueryable()
        {
            var query = Collection.AsQueryable();
            return query.OrderByDescending(e => e.CreateTime);
        }

        /// <summary>
        /// 根据条件，返回排序查询源
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderByKeySelector"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Queryable<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderByKeySelector, bool isDescending = true)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            var query = Collection.AsQueryable().Where(predicate);
            if (orderByKeySelector != null)
                query = isDescending ? query.OrderByDescending(orderByKeySelector) : query.OrderBy(orderByKeySelector);
            return query;
        }

        /// <summary>
        /// 根据条件，返回排序链表查询源
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderByPropertyName"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public virtual IFindFluent<T,T> FluentQueryable(FilterDefinition<T> filter, string orderByPropertyName, bool isDescending = true)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));
            var fluent = Collection.Find(filter);
            if (string.IsNullOrWhiteSpace(orderByPropertyName))
                return fluent;

            var sortDefinitionBuilder = new SortDefinitionBuilder<T>();
            var sort = isDescending ? sortDefinitionBuilder.Descending(orderByPropertyName) : sortDefinitionBuilder.Ascending(orderByPropertyName);
            return fluent.Sort(sort);
        }


        /// <summary>
        /// 根据条件，返回文档集合
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderByKeySelector"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> SelectAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderByKeySelector, bool isDescending = true)
        {
            var query = Collection.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (orderByKeySelector == null)
                return await query.ToListAsync();

            var result = isDescending ? query.OrderByDescending(orderByKeySelector) : query.OrderBy(orderByKeySelector);
            return await result.ToListAsync();
        }

        /// <summary>
        /// 根据条件，返回文档集合
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderByPropertyName"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> SelectAsync(FilterDefinition<T> filter, string orderByPropertyName, bool isDescending = true)
        {
            var fluent = Collection.Find(filter);
            if (string.IsNullOrWhiteSpace(orderByPropertyName))
                return await fluent.ToListAsync();

            var sortDefinitionBuilder = new SortDefinitionBuilder<T>();
            var sort = isDescending ? sortDefinitionBuilder.Descending(orderByPropertyName) : sortDefinitionBuilder.Ascending(orderByPropertyName);
            return await fluent.Sort(sort).ToListAsync();
        }

        /// <summary>
        /// 根据条件，返回分页的文档集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual async  Task<IPaged<T>> PagedSelectAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 20;

            var query = Collection.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            var recordTotal = query.Count();
            var pageTotal = recordTotal/pageSize;
            if (recordTotal%pageSize > 0) pageTotal++;

            if (pageIndex > 1)
                query = query.Skip((pageIndex - 1)*pageSize);
            var records = await query.Take(pageSize).ToListAsync();

            var pagedList = new Paged<T>()
            {
                PageTotal = pageTotal,
                RecordTotal = recordTotal,
                Index = pageIndex,
                Size = pageSize
            };
            pagedList.AddRange(records);
            return pagedList;
        }

        /// <summary>
        /// 根据条件，返回分页的文档集合
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual async Task<IPaged<T>> PagedSelectAsync(FilterDefinition<T> filter, int pageIndex, int pageSize)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 20;

            var fluent = Collection.Find(filter);
            var recordTotal = fluent.Count();
            var pageTotal = recordTotal / pageSize;
            if (recordTotal % pageSize > 0) pageTotal++;

            if (pageIndex > 1)
                fluent = fluent.Skip((pageIndex - 1) * pageSize);
            var records = await fluent.Limit(pageSize).ToListAsync();

            var pagedList = new Paged<T>()
            {
                PageTotal = (int)pageTotal,
                RecordTotal = (int)recordTotal,
                Index = pageIndex,
                Size = pageSize
            };
            pagedList.AddRange(records);
            return pagedList;
        }

        /// <summary>
        /// 插入文档
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(T item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));
            await Collection.InsertOneAsync(item);
        }

        /// <summary>
        /// 批量插入文档
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual async Task AddBatchAsync(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            await Collection.InsertManyAsync(items);
        }

        /// <summary>
        /// 根据主键，更新文档
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(T item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));
            if(string.IsNullOrWhiteSpace(item.Id))
                throw new ArgumentNullException(nameof(item.Id));

            //IsUpsert = true, 没有记录则插入
            var updated = await Collection.ReplaceOneAsync(e => e.Id == item.Id, item, new UpdateOptions() {IsUpsert = true});
            return updated != null && updated.ModifiedCount > 0;
        }

        /// <summary>
        /// 根据Id,更新部分字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(string id, UpdateDefinition<T> data)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            //IsUpsert = true, 没有记录则插入
            var updated = await Collection.UpdateOneAsync(e => e.Id == id, data, new UpdateOptions() { IsUpsert = true });
            return updated != null && updated.ModifiedCount > 0;
        }

        /// <summary>
        /// 根据Id, 删除文档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            var deleted = await Collection.DeleteOneAsync(e => e.Id == id);
            return deleted != null && deleted.DeletedCount > 0;
        }

        /// <summary>
        /// 根据多个Id, 批量删除文档
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteBatchAsync(IEnumerable<string> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var deleted = await Collection.DeleteManyAsync(e => ids.Contains(e.Id));
            return deleted != null && deleted.DeletedCount > 0;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteByAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var ids = await Collection.AsQueryable().Where(predicate).Select(e => e.Id).ToListAsync();
            var deleted = await Collection.DeleteManyAsync(e => ids.Contains(e.Id));
            return deleted != null && deleted.DeletedCount > 0;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteByAsync(FilterDefinition<T> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var items = await Collection.Find(filter).ToListAsync();
            var ids = items.Select(e => e.Id).ToList();
            var deleted = await Collection.DeleteManyAsync(e => ids.Contains(e.Id)); 
            return deleted != null && deleted.DeletedCount > 0;
        }


    }
}
