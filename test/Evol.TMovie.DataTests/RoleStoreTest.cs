using Evol.Domain;
using Evol.Domain.Uow;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using System.Linq;
using System;
using Xunit;
using Xunit.Abstractions;
using Evol.TMovie.Domain.Models.Entities;
using System.Collections.Generic;

namespace Evol.TMovie.DataTests
{
    public class RoleStoreTest
    {
        private IRoleQueryEntry _roleQueryEntry;

        private IRoleRepository _roleRepository;

        private IPermissionQueryEntry _permissionQueryEntry;

        private IPermissionRepository _permissionRepository;

        private IRolePermissionShipRepository _rolePermissionShipRepository;

        private IUnitOfWork _uow;

        private ITestOutputHelper _output;

        public RoleStoreTest(ITestOutputHelper output)
        {
            new Startup();
            var uowManager = AppConfig.Current.IoCManager.GetService<IUnitOfWorkManager>();
            _uow = uowManager.Build();
            _roleQueryEntry = AppConfig.Current.IoCManager.GetService<IRoleQueryEntry>();
            _roleRepository = AppConfig.Current.IoCManager.GetService<IRoleRepository>();
            _permissionQueryEntry = AppConfig.Current.IoCManager.GetService<IPermissionQueryEntry>();
            _permissionRepository = AppConfig.Current.IoCManager.GetService<IPermissionRepository>();
            _rolePermissionShipRepository = AppConfig.Current.IoCManager.GetService<IRolePermissionShipRepository>();
            _output = output;
        }

        [Fact]
        public void InsertOneRoleTest()
        {
            var item = new Role() { Id = Guid.NewGuid(), Code = "movieManager", Title = "电影管理员", Description = string.Empty, CreateTime = DateTime.Now };
            _roleRepository.InsertAsync(item).GetAwaiter().GetResult();
            _uow.SaveChangesAsync().GetAwaiter().GetResult();
            _uow.CommitAsync().GetAwaiter().GetResult();
        }

        [Fact]
        public void InsertOneRolePermissionShipTest()
        {
            var moviePermissions = _permissionQueryEntry.AllAsync().GetAwaiter().GetResult();
            var role = _roleQueryEntry.RetrieveAsync(new RoleQueryParameter { Code = "movieManager" }).GetAwaiter().GetResult().FirstOrDefault();

            Assert.True(moviePermissions.Any() && role != null);

            var ships = new List<RolePermissionShip>();

            moviePermissions.ForEach(e => {
                var ship = new RolePermissionShip() { Id = Guid.NewGuid(), RoleId = role.Id, PermissionId = e.Id, CreateTime = DateTime.Now };
                ships.Add(ship);
            });

            ships.ForEach(e => {
                _rolePermissionShipRepository.InsertAsync(e);
            });
            _uow.SaveChangesAsync().GetAwaiter().GetResult();
            _uow.CommitAsync().GetAwaiter().GetResult();
        }

    }


}
