using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using AutoMapper.Configuration;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class UserCreateDto : IInputDto, ICanConfigMapTo<User>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<UserCreateDto, User>();
        }
    }
}
