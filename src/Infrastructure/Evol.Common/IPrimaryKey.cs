using System;

namespace Evol.Common
{
    /// <summary>
    /// 默认Guid主键类型约束
    /// </summary>
    public interface IPrimaryKey : IPrimaryKey<Guid>
    {
    }

    /// <summary>
    /// 泛型主键约束
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IPrimaryKey<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey Id { get; set; }
    }
}
