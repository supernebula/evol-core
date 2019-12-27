using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.SimpleDapper
{
    public abstract class BaseDapperSimpleRepository<TDbContext, T> where TDbContext : DapperSimpleDbContext, new()
    {
        private TDbContext _dbContext;

        public BaseDapperSimpleRepository()
        {
            _dbContext = new TDbContext();
        }

        public int Insert(string sql, T item)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Execute(sql, item);
            }
        }

        public int Insert(string sql)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Execute(sql);
            }
        }

        public async Task<int> InsertAsync(string sql, T item)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return await dbConnection.ExecuteAsync(sql, item);
            }
        }

        public int InsertRange(string sql, T[] items)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                var count = dbConnection.Execute(sql, items);
                return count;
            }
        }

        public async Task<int> InsertRangeAsync(string sql, T[] items)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                var count = await dbConnection.ExecuteAsync(sql, items);
                return count;
            }
        }

        public int Delete(string sql, object param)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Execute(sql, param);
            }
        }

        public async Task<int> DeleteAsync(string sql, object param)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return await dbConnection.ExecuteAsync(sql, param);
            }
        }

        public int Update(string sql, object param)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Execute(sql, param);
            }
        }

        public int Update(string sql)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Execute(sql);
            }
        }

        public async Task<int> UpdateAsync(string sql, object param)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return await dbConnection.ExecuteAsync(sql, param);
            }
        }

        public T Find(string sql, object param)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Query<T>(sql, param).FirstOrDefault();
            }
        }


        public T Find(string sql)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Query<T>(sql).FirstOrDefault();
            }
        }

        public async Task<T> FindAsync(string sql, object param)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                var list = await dbConnection.QueryAsync<T>(sql, param);
                return list.FirstOrDefault();
            }
        }

        public IEnumerable<T> Query(string sql, object param = null)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return dbConnection.Query<T>(sql, param);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync(string sql, object param = null)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                return await dbConnection.QueryAsync<T>(sql, param);
            }
        }

        public Tuple<IEnumerable<TResult1>, TResult2> QueryMulti<TResult1, TResult2>(string sqlMulti, object param = null)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                var reader = dbConnection.QueryMultiple(sqlMulti, param);
                var result1 = reader.Read<TResult1>();
                var result2 = reader.Read<TResult2>().FirstOrDefault();
                return new Tuple<IEnumerable<TResult1>, TResult2>(result1, result2);
            }
        }

        public async Task<Tuple<IEnumerable<TResult1>, TResult2>> QueryMultiAsync<TResult1, TResult2>(string sqlMulti, object param = null)
        {
            using (var dbConnection = _dbContext.GetOpenDbConnection())
            {
                var reader = await dbConnection.QueryMultipleAsync(sqlMulti, param);
                var result1 = reader.Read<TResult1>();
                var result2 = reader.Read<TResult2>().FirstOrDefault();
                return new Tuple<IEnumerable<TResult1>, TResult2>(result1, result2);
            }
        }




    }
}
