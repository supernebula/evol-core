using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Extensions.Configuration
{
    public interface ITypedConfigurationBuilder
    {
        /// <summary>
        /// 共享数据
        /// </summary>
        Dictionary<string, object> Properties { get; }

        IList<ITypedConfigurationSource> Sources { get; }

        IList<Type> StrongTypes { get;}

        void Add(ITypedConfigurationSource source);

        ITypedConfigurationRoot Build();
    }
}
