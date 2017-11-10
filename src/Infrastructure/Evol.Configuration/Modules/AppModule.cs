using System;
using System.Collections.Generic;
using System.Linq;
using Evol.Configuration.Ioc;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Configuration.Modules
{
    /// <summary>
    /// 模块（目前每个项目看作一个模块）初始化
    /// </summary>
    public abstract class AppModule
    {

        /// <summary>
        /// 管理依赖注入
        /// </summary>
        public IIoCManager IoCManager;

        protected AppModule()
        {
            IoCManager = AppConfig.Current.IoCManager;
        }

        public virtual void Initailize()
        {
        }

        public bool IsAppModule(Type type)
        {
            var tInfo = type.GetTypeInfo();
            return tInfo.IsPublic && tInfo.IsClass && (typeof(AppModule)).GetTypeInfo().IsAssignableFrom(type);
        }

        public List<Type> FindDependModuleTypes(Type moduleType)
        {
            if (moduleType == null)
                throw new ArgumentNullException(nameof(moduleType));
            if (!IsAppModule(moduleType))
                throw new ArgumentException($"参数{nameof(moduleType)}的类型{moduleType.FullName}不是{nameof(AppModule)}或其派生类");

            var list = new List<Type>();

            var mtypeInfo = moduleType.GetTypeInfo();
            if (!mtypeInfo.IsDefined(typeof(DependOnAttribute), true))
                return list;
            var attributes = mtypeInfo.GetCustomAttributes(typeof(DependOnAttribute), true).Cast<DependOnAttribute>();

            foreach (var attr in attributes)
            {
                list.AddRange(attr.DependedModuleTypes);
            }
            return list;
        }

        protected void InitDependModule<T>() where T :  AppModule, new()
        {
            var moduleTypes = this.FindDependModuleTypes(typeof(T));
            foreach (var type in moduleTypes)
            {
                var constructorInfo = type.GetTypeInfo().GetConstructors(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault();
                var moduleObj = (AppModule)constructorInfo.Invoke(new object[] { });
                moduleObj.Initailize();
            }
        }
    }
}
