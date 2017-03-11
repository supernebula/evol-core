using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.EntityFramework.Repository.Test.Core;
using Evol.EntityFramework.Repository.Test.Repositories;

namespace Evol.EntityFramework.Repository.Test
{
    [TestClass]
    public class BatchQueryTest
    {
        private DefualtDbContextFactory _dbContextFactory;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dbContextFactory = new DefualtDbContextFactory();
        }
        //[TestMethod]
        public void QueryLargeTest()
        {
            var context = _dbContextFactory.Create<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.Take(1000000);
            sw.Stop();
            context.Dispose();
            Trace.WriteLine("EF带跟踪 QueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void SqlQueryLargeTest()
        {
            var context = _dbContextFactory.Create<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.TakeByDbSql(1000000);
            sw.Stop();
            context.Dispose();
            Trace.WriteLine("EF无跟踪 SqlQueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }
    }
}
