using System;
using System.ComponentModel;
using Evol.EntityFrameworkCore.SqlServer.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Evol.Test.Models;

namespace Evol.EntityFrameworkCore.SqlServer.Tests
{
    public class NormalRepositoryTest
    {
        private NormalEntityFrameworkCoreRepository<FakeUser, TestDbContext> normalEfCoreRepos;

        public NormalRepositoryTest()
        {
            var testDbContext = new TestDbContext();
            normalEfCoreRepos = new NormalEntityFrameworkCoreRepository<FakeUser, TestDbContext>(testDbContext);
        }


        [Fact, Description("简单EfCore插入单个测试")]
        public void InsertTest()
        {
            var item = FakeUser.Fake();
            normalEfCoreRepos.InsertAsync(item).GetAwaiter().GetResult();
            var num = normalEfCoreRepos.SaveChanges();
            Assert.True(num == 1);
        }

        [Fact, Description("简单EfCore插入单个测试")]
        public void InsertRangeTest()
        {
            var list = new List<FakeUser>() { FakeUser.Fake(), FakeUser.Fake() };

            normalEfCoreRepos.InsertRangeAsync(list).GetAwaiter().GetResult();
            var num = normalEfCoreRepos.SaveChanges();
            Assert.True(num == list.Count);
        }

        [Fact, Description("简单EfCore更新测试")]
        public void UpdateTest()
        {
            var items = normalEfCoreRepos.SelectAsync(e => e.Gender == Util.GenderType.Male).Result;
            Assert.False(!items.Any());
            var one = items.First();

            one.RealName += "xunit";
            normalEfCoreRepos.Update(one);
            normalEfCoreRepos.SaveChanges();
        }

        [Fact, Description("简单EfCore删除测试")]
        public void DeleteTest()
        {

            var items = normalEfCoreRepos.SelectAsync(e => e.Gender == Util.GenderType.Male).Result;
            Assert.False(!items.Any());
            var one = items.First();
            normalEfCoreRepos.DeleteAsync(one).GetAwaiter().GetResult();
            normalEfCoreRepos.SaveChanges();
        }

        [Fact, Description("查找单个测试")]
        public void FindTest()
        {
            var items = normalEfCoreRepos.SelectAsync(e => e.Gender == Util.GenderType.Male).Result;
            Assert.False(!items.Any());

            var one = items.First();
            var item = normalEfCoreRepos.FindAsync(one.Id).Result;
            normalEfCoreRepos.SaveChanges();
        }

        [Fact, Description("查询列表测试")]
        public void SelectTest()
        {
            var males = normalEfCoreRepos.SelectAsync(e => e.Gender == Util.GenderType.Male).Result;
            Assert.True(males.Any());
        }

    }
}
