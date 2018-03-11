using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Sample.Domain.Models.AggregateRoots;

namespace Sample.Domain.Commands.Dto
{
    public class UserCreateDto : IInputDto, ICanConfigMapTo<User>
    {
        public string Nick { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AvatarPath { get; set; }


        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<UserCreateDto, User>();
        }
    }
}
