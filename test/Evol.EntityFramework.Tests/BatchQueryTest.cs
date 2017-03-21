using System.Diagnostics;
using Evol.EntityFramework.Repository.Test.Core;
using Evol.EntityFramework.Repository.Test.Repositories;
using Evol.EntityFramework.Tests;
using Xunit;

namespace Evol.EntityFramework.Repository.Test
{
    public class BatchQueryTest
    {
        private IEfDbContextProvider _dbContextProvider;

        public BatchQueryTest()
        {
            _dbContextProvider = new SingleEfDbContextProvider();
        }
        //[TestMethod]
        public void QueryLargeTest()
        {
            var context = _dbContextProvider.Get<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.Take(1000000);
            sw.Stop();
            context.Dispose();
            Trace.WriteLine("EF带跟踪 QueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }


        [Fact]
        public void SqlQueryLargeTest()
        {
            var context = _dbContextProvider.Get<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.TakeByDbSql(1000000);
            sw.Stop();
            context.Dispose();
            Trace.WriteLine("EF无跟踪 SqlQueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }
    }
}
