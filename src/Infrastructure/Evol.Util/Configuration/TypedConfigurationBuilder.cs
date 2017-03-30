using System;
using System.Collections.Generic;
using System.Linq;

namespace Evol.Util.Configuration
{
    public class TypedConfigurationBuilder : ITypedConfigurationBuilder
    {
        public Dictionary<string, object> Properties { get; }

        public IList<ITypedConfigurationSource> Sources { get; }

        public TypedConfigurationBuilder()
        {
            Sources = new List<ITypedConfigurationSource>();
            Properties = new Dictionary<string, object>();
        }

        public IList<Type> StrongTypes
        {
            get
            {
                return Sources.Select(e => e.StrongType).ToList();
            }
        }

        public void Add(ITypedConfigurationSource source)
        {
            Sources.Add(source);
        }

        public ITypedConfigurationRoot Build()
        {
            var list = new List<TypedConfiguration>();
            foreach (var source in Sources)
            {
                var configProvider = source.Build(this);
                var config = new TypedConfiguration(configProvider);
                list.Add(config);
            }
            return new TypedConfigurationRoot(list);
        }
    }
}
