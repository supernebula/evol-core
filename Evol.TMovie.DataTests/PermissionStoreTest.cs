using Evol.Domain;
using Evol.Domain.Uow;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Evol.TMovie.DataTests
{
    public class PermissionStoreTest
    {
        private IPermissionQueryEntry _permissionQueryEntry;

        private IPermissionRepository _permissionRepository;

        private IUnitOfWork _uow;

        private ITestOutputHelper _output;

        public PermissionStoreTest(ITestOutputHelper output)
        {
            new Startup();
            var uowManager = AppConfig.Current.IoCManager.GetService<IUnitOfWorkManager>();
            _uow = uowManager.Build();
            _permissionRepository = AppConfig.Current.IoCManager.GetService<IPermissionRepository>();
            _permissionQueryEntry = AppConfig.Current.IoCManager.GetService<IPermissionQueryEntry>();
            _output = output;
        }

        [Fact]
        public void InsertOnePermissionTest()
        {
            var item = new Permission() { Id = Guid.NewGuid(), Code = "movie.delete", Name = "É¾³ýµçÓ°", CreateTime = DateTime.Now };
            _permissionRepository.InsertAsync(item).GetAwaiter().GetResult();
            _uow.SaveChangesAsync().GetAwaiter().GetResult();
            _uow.CommitAsync().GetAwaiter().GetResult();
        }

    }
}
