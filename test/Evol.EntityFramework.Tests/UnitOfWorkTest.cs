using System;
using Xunit;
using Evol.EntityFramework.Uow;
using Evol.Domain.Data;
using Evol.EntityFramework.Repository.Test.Repositories;
using Evol.Test.Models;
using System.ComponentModel;
using Evol.Domain.Uow;
using Evol.EntityFramework.Tests;

namespace Evol.EntityFramework.Repository.Test
{
    /// <summary>
    /// UnitOfWorkTest 的摘要说明
    /// </summary>
    public class UnitOfWorkTest
    {
        public IUnitOfWork UnitOfWorkObj;

        [ThreadStatic]
        private static IEfDbContextProvider _dbContextProvider;

        public UnitOfWorkTest()
        {
            _dbContextProvider = new EfUnitOfWorkDbContextProvider(new EfUnitOfWork());
        }

        [Fact,Description("EntityFramework工作单元依赖于事务，关键在于：针对数据库的多个更新统一提交，使用同一个DbContext")]
        public void MuiltChangeTest()
        {
            var unitOfWorkObj = new EfUnitOfWork();//{ DbContextFactory = _dbContextFactory };

            var uoWdbContextProvider = new EfUnitOfWorkDbContextProvider(unitOfWorkObj);
            var orderRepo = new FakeOrderRepository(uoWdbContextProvider) ;
            var productRepo = new FakeProductRepository(uoWdbContextProvider) ;
            var userRepo = new FakeUserRepository(uoWdbContextProvider) ; 

            unitOfWorkObj.Begin(new UnitOfWorkOption());
            try
            {
                //orderRepo.Insert(FakeOrder.Fake());
                productRepo.Insert(FakeProduct.Fake());
                userRepo.Insert(FakeUser.Fake());
                unitOfWorkObj.CommitAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                //Assert.F("发生异常：" + ex.Message);
            }
            finally
            {
                unitOfWorkObj.Dispose();
            }
        }


        #region template

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #endregion
    }
}
