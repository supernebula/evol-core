using AutoMapper;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using AutoMapper.Configuration;

namespace Evol.TMovie.Manage.Models
{
    public class CinemaViewModel : IOutputDto, ICanConfigMapFrom<Cinema>
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 影院地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Cinema, CinemaViewModel>();
        }
    }
}
