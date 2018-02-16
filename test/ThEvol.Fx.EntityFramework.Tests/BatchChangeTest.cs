//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using Xunit;
//using Evol.Fx.EntityFramework.Repository.Test.Core;
//using Evol.Fx.EntityFramework.Repository.Test.Repositories;
//using Evol.Tests.Models;
//using Evol.Util;
//using Evol.Fx.EntityFramework.Tests;
//using Evol.EntityFramework.Repository;

//namespace Evol.Fx.EntityFramework.Repository.Test
//{
//    /// <summary>
//    /// ConcurrentTest 的摘要说明
//    /// </summary>
//    public class BatchChangeTest
//    {

//        private IEfDbContextProvider _dbContextProvider;

//        public BatchChangeTest()
//        {
//            _dbContextProvider = new SingleEfDbContextProvider();
//        }

//        public void MyTestCleanup()
//        {

            
//        }

//        public void BatchInsertTest()
//        {
//            var total = 200;
//            var context = _dbContextProvider.Get<FakeEcDbContext>();
//            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
//            var sw = new Stopwatch();
//            sw.Start();

//            var users = CreateOneUser(total);
//            var time1 = sw.ElapsedMilliseconds;
//            sw.Restart();
//            fakeUserRepo.InsertRangeAsync(users).GetAwaiter();
//            context.SaveChanges();
//            sw.Stop();
//            context.Dispose();

//            Trace.WriteLine("Create FakeUser " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
//            Trace.WriteLine("Batch Insert " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
//        }


//        [Fact]
//        public void SqlBatchInsertTest()
//        {
//            var total = 200;
//            var context = _dbContextProvider.Get<FakeEcDbContext>();
//            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
//            var sw = new Stopwatch();
//            sw.Start();

//            var users = CreateOneUser(total);
//            var time1 = sw.ElapsedMilliseconds;
//            sw.Restart();

//            var realTotal = users.Sum(item => fakeUserRepo.InsertByCommand(item));
//            sw.Stop();
//            context.Dispose();

//            Trace.WriteLine("Create FakeUser " + total + ", 毫秒：" + time1);
//            Trace.WriteLine("Sql Batch Insert " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
//        }


//        [Fact]
//        public void InsertOneTest()
//        {
//            var context = _dbContextProvider.Get<FakeEcDbContext>();
//            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
//            var sw = new Stopwatch();
//            sw.Start();

//            var user = CreateOneUser();
//            fakeUserRepo.InsertAsync(user).GetAwaiter();
//            context.SaveChanges();
//            sw.Stop();
//            Trace.WriteLine("Insert " + 1 + ", 毫秒：" + sw.ElapsedMilliseconds);
//            context.Dispose();
//        }

//        [Fact]
//        public void SqlInsertOneTest()
//        {
//            var context = _dbContextProvider.Get<FakeEcDbContext>();
//            var fakeUserRepo = new FakeUserRepository(_dbContextProvider);
//            var sw = new Stopwatch();
//            sw.Start();

//            var user = CreateOneUser();
//            var count = fakeUserRepo.InsertByCommand(user);
//            sw.Stop();
//            Trace.WriteLine("Sql Insert " + count + ", 毫秒：" + sw.ElapsedMilliseconds);
//            context.Dispose();
//        }


//        private List<FakeUser> CreateOneUser(int total)
//        {
            
//            var list = new List<FakeUser>();
//            if (total < 1)
//                return list;
//            for (int i = 0; i < total; i++)
//            {
//                var gender = FakeUtil.CreateGender();
//                var fakeUser = new FakeUser()
//                {
//                    Id = FakeUtil.CreateGuid(),
//                    RealName = FakeUtil.CreatePersonName(gender),
//                    Username = FakeUtil.CreateUsername(),
//                    Password = FakeUtil.CreatePassword(),
//                    Address = "XXXX路yy号",
//                    Mobile = FakeUtil.CreateMobile(),
//                    Email = FakeUtil.CreateEmail(),
//                    Points = FakeUtil.RandomInt(0, 100),
//                    Birthday = FakeUtil.CreateBirthday(),
//                    PersonHeight = FakeUtil.CreatePersonHeight(),
//                    CreateTime = DateTime.Now
//                };

//                list.Add(fakeUser);

//            }
//            return list;
//        }

//        private FakeUser CreateOneUser()
//        {
//            var gender = FakeUtil.CreateGender();
//            var fakeUser = new FakeUser()
//            {
//                Id = FakeUtil.CreateGuid(),
//                RealName = FakeUtil.CreatePersonName(gender),
//                Username = FakeUtil.CreateUsername(),
//                Password = FakeUtil.CreatePassword(),
//                Address = "XXXX路yy号",
//                Mobile = FakeUtil.CreateMobile(),
//                Email = FakeUtil.CreateEmail(),
//                Points = FakeUtil.RandomInt(0, 100),
//                Birthday = FakeUtil.CreateBirthday(),
//                PersonHeight = FakeUtil.CreatePersonHeight(),
//                CreateTime = DateTime.Now
//            };
//            return fakeUser;
//        }
//    }
//}
