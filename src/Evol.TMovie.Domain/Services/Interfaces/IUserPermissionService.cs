using Evol.Domain.Service;
using Evol.TMovie.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.Services
{
    public interface IUserPermissionService : IService
    {
        Task<UserPermissionDto> GetAsync(Guid userId);

    }
}
