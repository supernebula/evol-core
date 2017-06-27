using Evol.Domain.Dto;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using AutoMapper.Configuration;

namespace Evol.TMovie.Manage.Models
{
    public class PermissonViewModel : IOutputDto, ICanOptionMapFrom<Permission>
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Permission, PermissonViewModel>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id)); //实例
        }
    }
}
