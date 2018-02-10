using System;
using Xunit;
using System.Threading.Tasks;
using Evol.UnitOfWork.Abstractions;

namespace Evol.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void UowManagerTest1()
        {
            var uowManager = Moq.Mock.Of<IMultiUnitOfWorkManager>();
            var uow = uowManager.Begin();


            await uow.CommitAsync();
        }


        [Fact]
        public async void UowBuildTest()
        {
            await UnitOfWorkBuild.UnitOfWork().RunAsync(async () =>
            {
                await Task.FromResult(0);
            });
        }
    }
}
