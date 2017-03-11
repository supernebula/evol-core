using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.Dapper.Repository.Test
{
    [TestClass]
    public class BatchQueryTest
    {
        private DbContextFactory<FakeEcDbContext> _dbContextFactory;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dbContextFactory = new DbContextFactory<FakeEcDbContext>();
        }
        [TestMethod]
        public void QueryLargeTest()
        {
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.Take(1000000);
            sw.Stop();
            fakeUserRepo.Dispose();
            Trace.WriteLine("DapperQueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }
    }
}
