using System;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    /// <summary>
    /// 电影查询参数对象
    /// </summary>
    public class MovieQueryParameter
    {
        /// <summary>
        /// 电影名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 发行日期
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// 发行地区
        /// </summary>
        public string ReleaseRegion { get; set; }

        /// <summary>
        /// 空间类型
        /// </summary>
        public SpaceDimensionType? SpaceType { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }
    }
}
