using Evol.Common.IoC;
using System.Diagnostics;
using Xunit;

namespace Evol.Dapper.Repository.Test
{
    public class BatchQueryTest
    {
        private DapperDbContextProvider _dbContextProvider;

        public void MyTestInitialize()
        {
            _dbContextProvider = new DapperDbContextProvider(default(IIoCManager));
        }
        [Fact]
        public void QueryLargeTest()
        {
            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.Take(1000000);
            sw.Stop();
            fakeUserRepo.Dispose();
            Trace.WriteLine("DapperQueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }
    }
}
