using System;
using Evol.Common.Logging;
using Xunit;
using Evol.Fx.Logging.AdapteNLog;
using Evol.Util.Serialization;
using System.Threading;

namespace Evol.Logging.AdapteNLog.FxTests
{
    public class LogDataTest
    {
        private NLoggerFactory logFactory;

        private ILogger log;

        [Fact]
        public void OperateLogToDbTest()
        {
            var testModel = new TestModel {
                Id = Guid.NewGuid(),
                TestTitle = "测试操作日志",
                TestNumber = 2,
                TestDateTime = DateTime.Now
            };

            logFactory = new NLoggerFactory();

            //创建日志对象
            log = logFactory.CreateLogger("operateLog");

            //日志数据赋值
            var actionLog = new OperateLog() {
                Id = Guid.NewGuid(),
                Ip = "127.0.0.1",
                OperatorId = Guid.NewGuid().ToString(),
                OperAccount = "Account1",
                OperBranch = "运营1",
                OperType = OperatorType.Member,
                OperRemark = "操作备注",
                MemberId = Guid.NewGuid().ToString(),
                OriginalValue = JsonUtil.Serialize(new { Model = typeof(TestModel).Name, EntityId = testModel.Id, Title = testModel.TestTitle, 价格 = 99.0 }),
                ModifiedValue = JsonUtil.Serialize(new { Title = testModel.TestTitle + "修改后" , 价格 = 59.0 }),
                ModelType = typeof(TestModel).FullName,
                Action = HandleActionType.Modify,
                SubAction =  SubHandleActionType.None,
                Business = "订单模块",
                Remark = "这是备注说明",
                CreateTime = DateTime.Now
            };

            //插入数据库
            log.LogData(actionLog);

            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// 测试实体
    /// </summary>
    public class TestModel
    {
        public Guid Id { get; set; }

        public string TestTitle { get; set; }

        public int TestNumber { get; set; }

        public DateTime TestDateTime { get; set; }
    }

    /// <summary>
    /// 动作日志
    /// </summary>
    public class OperateLog
    {
        public OperateLog()
        {
            OriginalValue = string.Empty;
            ModifiedValue = string.Empty;
            Remark = string.Empty;
        }

        public Guid Id { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作人账号
        /// </summary>
        public string OperAccount { get; set; }

        /// <summary>
        /// 操作人所在部门
        /// </summary>
        public string OperBranch { get; set; }

        /// <summary>
        /// 操作人身份类型
        /// </summary>
        public OperatorType OperType { get; set; }


        /// <summary>
        /// 动作int值，在nlog target中使用，
        /// 因nlog使用枚举的ToString()得到成员名称字符串，插入int字段，造成写入数据库失败
        /// </summary>
        public int OperTypeIntVal => (int)OperType;

        /// <summary>
        /// 操作备注
        /// </summary>
        public string OperRemark { get; set; }

        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 原始值
        /// </summary>
        public string OriginalValue { get; set; }

        /// <summary>
        /// 修改后的值
        /// </summary>
        public string ModifiedValue { get; set; }


        /// <summary>
        /// 实体类型
        /// </summary>
        public string ModelType { get; set; }


        /// <summary>
        /// 动作
        /// </summary>
        public HandleActionType Action { get; set; }

        /// <summary>
        /// 子动作
        /// </summary>
        public SubHandleActionType SubAction { get; set; }


        /// <summary>
        /// 动作int值，在nlog target中使用，
        /// 因nlog使用枚举的ToString()得到成员名称字符串，插入int字段，造成写入数据库失败
        /// </summary>
        public int ActionIntVal => (int)Action;


        /// <summary>
        /// 子动作int值，在nlog target中使用，
        /// 因nlog使用枚举的ToString()得到成员名称字符串，插入int字段，造成写入数据库失败
        /// </summary>
        public int SubActionIntVal => (int)SubAction;

        /// <summary>
        /// 业务模块，例如：商品、订单....
        /// </summary>
        public string Business { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }

    public enum OperatorType : int
    {
        /// <summary>
        /// 公司员工
        /// </summary>
        Staff = 0,

        /// <summary>
        /// 会员
        /// </summary>
        Member = 0
    }

    /// <summary>
    /// 执行动作
    /// </summary>
    public enum HandleActionType : int
    {
        /// <summary>
        /// 创建
        /// </summary>
        Create = 0,

        /// <summary>
        /// 修改
        /// </summary>
        Modify = 1,

        /// <summary>
        /// 查看
        /// </summary>
        View = 2,

        /// <summary>
        /// 删除
        /// </summary>
        Delete = 3,

        /// <summary>
        /// 登录
        /// </summary>
        Login = 11
    }

    /// <summary>
    /// 执行子动作
    /// </summary>
    public enum SubHandleActionType : int
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,

        /// <summary>
        /// 创建
        /// </summary>
        CreateOrder = 1,

        /// <summary>
        /// 修改
        /// </summary>
        UpdateOrderStatus = 2
    }


}
