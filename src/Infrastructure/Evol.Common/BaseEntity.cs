using System;

namespace Evol.Common
{
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }

    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public TKey Id { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }

}
