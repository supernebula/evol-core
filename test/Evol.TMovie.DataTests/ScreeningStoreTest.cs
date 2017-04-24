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
    public class ScreeningStoreTest
    {
        private IScreeningQueryEntry _screeningQueryEntry;

        private IScreeningRepository _screeningRepository;

        private IUnitOfWork _uow;

        private ITestOutputHelper _output;

        public ScreeningStoreTest(ITestOutputHelper output)
        {
            new Startup();
            var uowManager = AppConfig.Current.IoCManager.GetService<IUnitOfWorkManager>();
            _uow = uowManager.Build();
            _screeningRepository = AppConfig.Current.IoCManager.GetService<IScreeningRepository>();
            _screeningQueryEntry = AppConfig.Current.IoCManager.GetService<IScreeningQueryEntry>();
            _output = output;
        }

        [Fact]
        public void InsertOneRoleTest()
        {
            throw new NotImplementedException();
            var item = new Screening();
            _screeningRepository.InsertAsync(item).GetAwaiter().GetResult();
            _uow.SaveChangesAsync().GetAwaiter().GetResult();
            _uow.CommitAsync().GetAwaiter().GetResult();
        }
    }


}

