using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using AutoMapper.Configuration;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Manage.Models
{
    /// <summary>
    /// 电影ViewModel
    /// </summary>
    public class MovieViewModel : IOutputDto, ICanConfigMapFrom<Movie>
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 外语名称
        /// </summary>
        public string ForeignName { get; set; }

        /// <summary>
        /// 发行日期
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// 时间长度
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// 发行地区
        /// </summary>
        public string ReleaseRegion { get; set; }

        /// <summary>
        /// 空间维度
        /// </summary>
        public SpaceDimensionType SpaceType { get; set; }

        /// <summary>
        /// 演员
        /// </summary>
        public List<Actor> Actors { get; set; }

        /// <summary>
        /// 封面图片地址
        /// </summary>
        public string CoverUri { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public List<string> Categorys { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public float Ratings { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Movie, MovieViewModel>();
        }
    }
}
