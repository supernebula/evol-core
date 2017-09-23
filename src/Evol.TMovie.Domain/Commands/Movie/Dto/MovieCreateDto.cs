using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Values;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class MovieCreateDto : IInputDto, ICanConfigMapTo<Movie>
    {

        public Guid ProductId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; }

        /// <summary>
        /// 外语名称
        /// </summary>
        [Required]
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
        [Required]
        public string ReleaseRegion { get; set; }

        /// <summary>
        /// 空间维度
        /// </summary>
        public SpaceDimensionType SpaceType { get; set; }

        /// <summary>
        /// 演员
        /// </summary>
        [Required]
        public List<Actor> Actors { get; set; }

        /// <summary>
        /// 封面图片地址
        /// </summary>
        [Required]
        public string CoverUri { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Required]
        public List<string> Categorys { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [Required]
        public List<string> Tags { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public float Ratings { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [Required]
        public string Language { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<MovieCreateDto, Movie>();
        }
    }
}
