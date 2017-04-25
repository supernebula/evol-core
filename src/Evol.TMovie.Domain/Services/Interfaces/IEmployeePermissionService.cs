using Evol.Domain.Service;
using Evol.TMovie.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.Services
{
    public interface IEmployeePermissionService : IService
    {
        Task<EmployeePermissionDto> GetAsync(Guid employeeId);

        Task<bool> ValidatePermissionAsync(Guid employeeId, string permissionCode, string httpSessionId);

    }
}
