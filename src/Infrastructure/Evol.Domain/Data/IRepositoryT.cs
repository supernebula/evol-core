using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Common;

namespace Evol.Domain.Data
{
    /// <summary>
    /// 基础仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T,TKey> where T : IPrimaryKey<TKey>
    {
        /// <summary>
        /// 查找一个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<T> FindAsync(TKey id);

        /// <summary>
        /// 查询多个
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查找多个
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns></returns>
        Task<List<T>> SelectAsync(TKey[] ids);

        /// <summary>
        /// 查询多个
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<List<T>> SelectAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 流利查询对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();

        /// <summary>
        /// 插入一个
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// 插入多个
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task InsertRangeAsync(IEnumerable<T> items);

        /// <summary>
        /// 更新一个
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateAsync(T item);

        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task DeleteAsync(T item);

        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(TKey id);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页条数</param>
        /// <returns></returns>
        Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页条数</param>
        /// <returns></returns>
        Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize);

    }
}
