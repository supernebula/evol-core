using Microsoft.Extensions.Primitives;
using System;

namespace Evol.Util.Configuration
{
    public interface ITypedConfigurationProvider
    {
        Type StrongType { get; }

        bool TryGet<T>(out T value) where T : class;

        object GetValue();

        IChangeToken GetReloadToken();

        void Load();
    }
}
