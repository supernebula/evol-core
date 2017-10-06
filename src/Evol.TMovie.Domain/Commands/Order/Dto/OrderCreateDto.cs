using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class OrderCreateDto : IInputDto, ICanConfigMapTo<Order>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public int ItemCount { get; set; }

        public float Amount { get; set; }

        public List<OrderDetail> Items { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<OrderCreateDto, Order>();
        }
    }
}
