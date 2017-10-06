using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using AutoMapper.Configuration;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Manage.Models
{
    public class OrderViewModel : IOutputDto, ICanConfigMapFrom<Order>
    {
        public string No { get; set; }
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public int ItemCount { get; set; }

        public float Amount { get; set; }

        public OrderStatusType Status { get; set; }

        public DateTime? PayTime { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Order, OrderViewModel>();
        }
    }
}
