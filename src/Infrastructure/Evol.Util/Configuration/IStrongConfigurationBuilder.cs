using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public interface IStrongConfigurationBuilder
    {
        /// <summary>
        /// 共享数据
        /// </summary>
        Dictionary<string, object> Properties { get; }

        IList<IStrongConfigurationSource> Sources { get; }

        IList<Type> StrongTypes { get;}

        void Add(IStrongConfigurationSource source);

        IStrongConfigurationRoot Build();
    }
}
