
namespace Evol.Common.IoC
{
    /// <summary>
    /// 依赖注入(控制反转)生命周期
    /// </summary>
    public enum IocLifetime
    {
        /// <summary>
        /// 每依赖
        /// </summary>
        PerDependency,

        /// <summary>
        /// 没请求
        /// </summary>
        PerRequest,

        /// <summary>
        /// 单例
        /// </summary>
        SingleInstance

    }
}
