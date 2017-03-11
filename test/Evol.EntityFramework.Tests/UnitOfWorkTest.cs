using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.Common.Repository;
using Evol.Domain.Data;
using Evol.EntityFramework.Repository.Test.Repositories;
using Evol.Test.Model;

namespace Evol.EntityFramework.Repository.Test
{
    /// <summary>
    /// UnitOfWorkTest 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitOfWorkTest
    {
        public IUnitOfWork UnitOfWorkObj;

        [ThreadStatic]
        private static IDbContextFactory _dbContextFactory;

        [TestInitialize]
        public void Init()
        {
            _dbContextFactory = new DefualtDbContextFactory();
        }

        [TestMethod,Description("EntityFramework工作单元依赖于事务，关键在于：针对数据库的多个更新统一提交，使用同一个DbContext")]
        public void MuiltChangeTest()
        {
            var unitOfWorkObj = new EfUnitOfWork();//{ DbContextFactory = _dbContextFactory };

            var unitOfWorkDbContextFactory = new DefualtDbContextFactory() { UnitOfWork = unitOfWorkObj };
            var orderRepo = new FakeOrderRepository()  {  DbContextFactory = unitOfWorkDbContextFactory };
            var productRepo = new FakeProductRepository() { DbContextFactory = unitOfWorkDbContextFactory };
            var userRepo = new FakeUserRepository() { DbContextFactory = unitOfWorkDbContextFactory }; 

            unitOfWorkObj.BeginTransaction(new UnitOfWorkOptions());
            try
            {
                //orderRepo.Insert(FakeOrder.Fake());
                productRepo.Insert(FakeProduct.Fake());
                userRepo.Insert(FakeUser.Fake());
                unitOfWorkObj.Commit();
            }
            catch (Exception ex)
            {
                unitOfWorkObj.RollBack();
                Assert.Fail("发生异常：" + ex.Message);
            }
            finally
            {
                unitOfWorkObj.Dispose();
            }
        }


        #region template

        private TestContext _testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

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
