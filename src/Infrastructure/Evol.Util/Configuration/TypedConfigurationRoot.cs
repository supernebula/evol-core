using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Evol.Util.Configuration
{
    public class TypedConfigurationRoot : ITypedConfigurationRoot
    {

        public TypedConfigurationRoot(IEnumerable<ITypedConfiguration> strongConfigurations)
        {
            Configurations = new ReadOnlyCollection<ITypedConfiguration>(strongConfigurations.ToList());
        }
        public IList<ITypedConfiguration> Configurations { get; private set; }

        public T GetValue<T>()
        {
            var type = typeof(T);
            return (T)GetValue(type);
        }

        public object GetValue(Type type)
        {
            var config = Configurations.FirstOrDefault(e => e.StrongType == type);
            if (config == null)
                throw new KeyNotFoundException("未添加该类型的配置文件");
            return config.GetValue();
        }
    }
}
