using System.ComponentModel;

namespace Evol.Fx.EntityFramework.Repository.Test
{
    /// <summary>
    /// 未测试实现的功能 EntityFramework
    /// https://msdn.microsoft.com/zh-cn/data/ee712907
    /// </summary>
    public class NotImplementedFunc
    {
        [Description("决乐观并发")]
        public void OptimisticConcurrencyTest()
        {
            //文档:https://msdn.microsoft.com/zh-cn/data/jj592904
            //使用 Reload 解决乐观并发异常（数据库优先）
            //以“数据库优先”方式解决乐观并发异常
            //自定义解决乐观并发异常
            //使用对象自定义解决乐观并发异常
            
            //...............更多
        }

        [Description("使用代理")]
        public void UseAgentTest()
        {
            //文档:https://msdn.microsoft.com/zh-cn/data/jj592886
            //禁止创建代理
            //显式创建代理实例
            //从代理类型获取实际实体类型

            //...............更多
        }


        /// <summary>
        /// Using Local to look at local data
        /// </summary>
        [Description("使用本地数据")]
        public void UsingLocalTest()
        {
            //文档:https://msdn.microsoft.com/zh-cn/data/jj592872

            //...............更多
        }


        /// <summary>
        /// Using Local to look at local data
        /// </summary>
        [Description("其他。。")]
        public void OtherTest()
        {
            //...............更多
        }
    }
}
