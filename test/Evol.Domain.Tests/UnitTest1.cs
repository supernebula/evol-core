using System;
using Xunit;
using Evol.Domain.Uow;
using System.Threading.Tasks;

namespace Evol.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void UowManagerTest1()
        {
            var uowManager = Moq.Mock.Of<IUnitOfWorkManager>();
            var uow = uowManager.Begin();


            await uow.CommitAsync();
        }


        [Fact]
        public async void UowBuildTest()
        {
            await UnitOfWorkBuild.UseOption().RunAsync(async () =>
            {
                await Task.FromResult(0);
            });
        }
    }
}
