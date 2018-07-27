using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using Evol.Common;

namespace Evol.Dapper.Repository
{
    public class BasicDapperRepository<T, TDbContext> : IDisposable where TDbContext : DapperDbContext, new() where T : class, IPrimaryKey
    {

        private TDbContext _context;

        //[Dependency]
        public IDapperDbContextProvider DbContextProvider { get; set; }

        private DapperDbContext DbContext
        {
            get
            {
                return _context = _context ?? DbContextProvider.Get<TDbContext>();
            }
        }

        public BasicDapperRepository(IDapperDbContextProvider dbConnectionProvider)
        {
            DbContextProvider = dbConnectionProvider;
        }


        public IDbConnection DbConnection => DbContext.DbConnection;

        public int Insert(string sql, T item)
        {
            return DbConnection.Execute(sql, item);
        }

        public int InsertRange(string sql, T[] items)
        {
            return DbConnection.Execute(sql, items);
        }

        public int Delete(string sql, object param)
        {
            return DbConnection.Execute(sql, param);
        }

        public T Find(string sql, object param)
        {
            return DbConnection.Query<T>(sql, param).FirstOrDefault();
        }

        public IEnumerable<T> Query(string sql, object param = null)
        {
            return DbConnection.Query<T>(sql, param);
        }

        public Tuple<IEnumerable<TResult1>, TResult2>  QueryMulti<TResult1, TResult2>(string sqlMulti, object param = null)
        {
            
            var reader =  DbConnection.QueryMultiple(sqlMulti, param);
            var result1 = reader.Read<TResult1>();
            var result2 = reader.Read<TResult2>().FirstOrDefault();
            return new Tuple<IEnumerable<TResult1>, TResult2>(result1, result2);
        }



        public int Update(string sql, object param)
        {
            return DbConnection.Execute(sql, param);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IPaged<T> Paged(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IPaged<T> Paged(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();


        }

        public void Dispose()
        {
            DbConnection.Close();
            DbConnection.Dispose();
        }
    }
}
