using System;
using System.Collections.Generic;
using System.Linq;

namespace Evol.Util.Configuration
{
    public class StrongConfigurationBuilder : IStrongConfigurationBuilder
    {
        public Dictionary<string, object> Properties { get; }

        public IList<IStrongConfigurationSource> Sources { get; }

        public StrongConfigurationBuilder()
        {
            Sources = new List<IStrongConfigurationSource>();
            Properties = new Dictionary<string, object>();
        }

        public IList<Type> StrongTypes
        {
            get
            {
                return Sources.Select(e => e.StrongType).ToList();
            }
        }

        public void Add(IStrongConfigurationSource source)
        {
            throw new NotImplementedException();
        }

        public IStrongConfigurationRoot Build()
        {
            var list = new List<StrongConfiguration>();
            foreach (var source in Sources)
            {
                var configProvider = source.Build(this);
                var config = new StrongConfiguration(configProvider);
                list.Add(config);
            }
            return new StrongConfigurationRoot(list);
        }
    }
}
