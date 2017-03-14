using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.EntityFramework.Repository.Test.Core;
using Evol.EntityFramework.Repository.Test.Repositories;
using Evol.Test.Model;
using Evol.Util;

namespace Evol.EntityFramework.Repository.Test
{
    /// <summary>
    /// ConcurrentTest 的摘要说明
    /// </summary>
    [TestClass]
    public class BatchChangeTest
    {

        private DefualtDbContextFactory _dbContextFactory;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dbContextFactory = new DefualtDbContextFactory();
        }

        public void MyTestCleanup()
        {

            
        }

        [TestMethod]
        public void BatchInsertTest()
        {
            var total = 200;
            var context = _dbContextFactory.Create<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();

            var users = CreateOneUser(total);
            var time1 = sw.ElapsedMilliseconds;
            sw.Restart();
            fakeUserRepo.InsertRange(users);
            context.SaveChanges();
            sw.Stop();
            context.Dispose();

            Trace.WriteLine("Create FakeUser " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
            Trace.WriteLine("Batch Insert " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void SqlBatchInsertTest()
        {
            var total = 200;
            var context = _dbContextFactory.Create<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();

            var users = CreateOneUser(total);
            var time1 = sw.ElapsedMilliseconds;
            sw.Restart();

            var realTotal = users.Sum(item => fakeUserRepo.InsertByCommand(item));
            sw.Stop();
            context.Dispose();

            Trace.WriteLine("Create FakeUser " + total + ", 毫秒：" + time1);
            Trace.WriteLine("Sql Batch Insert " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void InsertOneTest()
        {
            var context = _dbContextFactory.Create<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();

            var user = CreateOneUser();
            fakeUserRepo.Insert(user);
            context.SaveChanges();
            sw.Stop();
            Trace.WriteLine("Insert " + 1 + ", 毫秒：" + sw.ElapsedMilliseconds);
            context.Dispose();
        }

        [TestMethod]
        public void SqlInsertOneTest()
        {
            var context = _dbContextFactory.Create<FakeEcDbContext>();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();

            var user = CreateOneUser();
            var count = fakeUserRepo.InsertByCommand(user);
            sw.Stop();
            Trace.WriteLine("Sql Insert " + count + ", 毫秒：" + sw.ElapsedMilliseconds);
            context.Dispose();
        }


        private List<FakeUser> CreateOneUser(int total)
        {
            
            var list = new List<FakeUser>();
            if (total < 1)
                return list;
            for (int i = 0; i < total; i++)
            {
                var gender = FakeUtility.CreateGender();
                var fakeUser = new FakeUser()
                {
                    Id = FakeUtility.CreateGuid(),
                    RealName = FakeUtility.CreatePersonName(gender),
                    Username = FakeUtility.CreateUsername(),
                    Password = FakeUtility.CreatePassword(),
                    Address = "XXXX路yy号",
                    Mobile = FakeUtility.CreateMobile(),
                    Email = FakeUtility.CreateEmail(),
                    Points = FakeUtility.RandomInt(0, 100),
                    Birthday = FakeUtility.CreateBirthday(),
                    PersonHeight = FakeUtility.CreatePersonHeight(),
                    CreateTime = DateTime.Now
                };

                list.Add(fakeUser);

            }
            return list;
        }

        private FakeUser CreateOneUser()
        {
            var gender = FakeUtility.CreateGender();
            var fakeUser = new FakeUser()
            {
                Id = FakeUtility.CreateGuid(),
                RealName = FakeUtility.CreatePersonName(gender),
                Username = FakeUtility.CreateUsername(),
                Password = FakeUtility.CreatePassword(),
                Address = "XXXX路yy号",
                Mobile = FakeUtility.CreateMobile(),
                Email = FakeUtility.CreateEmail(),
                Points = FakeUtility.RandomInt(0, 100),
                Birthday = FakeUtility.CreateBirthday(),
                PersonHeight = FakeUtility.CreatePersonHeight(),
                CreateTime = DateTime.Now
            };
            return fakeUser;
        }
    }
}
