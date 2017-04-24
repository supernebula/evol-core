using Evol.Domain;
using Evol.Domain.Uow;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using System.Linq;
using System;
using Xunit;
using Evol.Util.Hash;
using Xunit.Abstractions;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Models.Entities;

namespace Evol.TMovie.DataTests
{
    public class EmployeeStoreTest
    {
        private IEmployeeQueryEntry _employeeQueryEntry;

        private IEmployeeRepository _employeeRepository;

        private IRoleQueryEntry _roleQueryEntry;

        private IPermissionQueryEntry _permissionQueryEntry;

        private IEmployeePermissionShipRepository _employeePermissionRepository;

        private IUnitOfWork _uow;

        private ITestOutputHelper _output;

        public EmployeeStoreTest(ITestOutputHelper output)
        {
            new Startup();
            var uowManager = AppConfig.Current.IoCManager.GetService<IUnitOfWorkManager>();
            _uow = uowManager.Build();
            _employeeRepository = AppConfig.Current.IoCManager.GetService<IEmployeeRepository>();
            _employeeQueryEntry = AppConfig.Current.IoCManager.GetService<IEmployeeQueryEntry>();
            _roleQueryEntry = AppConfig.Current.IoCManager.GetService<IRoleQueryEntry>();
            _permissionQueryEntry = AppConfig.Current.IoCManager.GetService<IPermissionQueryEntry>();
            _employeePermissionRepository = AppConfig.Current.IoCManager.GetService<IEmployeePermissionShipRepository>();
            _output = output;
        }

        [Fact]
        public void InsertOneEmployeeTest()
        {
            var salt = Guid.NewGuid().ToString();
            var hashedPassword = HashUtil.Md5PasswordWithSalt("123456", salt);
            var item = new Employee() { Id = Guid.NewGuid(), Username = "admin" , Password = hashedPassword, Salt = salt, RealName = "张三",  CreateTime = DateTime.Now };
            _employeeRepository.InsertAsync(item).GetAwaiter().GetResult();
            _uow.SaveChangesAsync().GetAwaiter().GetResult();
            _uow.CommitAsync().GetAwaiter().GetResult();
        }

        [Fact]
        public void InsertOneEmployeePermissionShipTest()
        {
            var employee = _employeeQueryEntry.PagedAsync(null, 1, 1).GetAwaiter().GetResult().FirstOrDefault();
            var role = _roleQueryEntry.PagedAsync(null, 1, 1).GetAwaiter().GetResult().FirstOrDefault();
            var permission = _permissionQueryEntry.RetrieveAsync(new PermissionQueryParameter { Code = "screening.publish" }).GetAwaiter().GetResult().FirstOrDefault();

            Assert.True(role != null && permission != null && employee != null);

            var roleShip = new EmployeePermissionShip() { Id = Guid.NewGuid(), EmployeeId = employee.Id, RoleId = role.Id, CreateTime = DateTime.Now };
            var customShip = new EmployeePermissionShip() { Id = Guid.NewGuid(), EmployeeId = employee.Id, CustomPermissionId = permission.Id, CreateTime = DateTime.Now };

            _employeePermissionRepository.InsertAsync(roleShip).GetAwaiter().GetResult();
            _employeePermissionRepository.InsertAsync(customShip).GetAwaiter().GetResult();
            _uow.SaveChangesAsync().GetAwaiter().GetResult();
            _uow.CommitAsync().GetAwaiter().GetResult();
        }
    }
}
