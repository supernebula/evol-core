using Microsoft.Extensions.Primitives;

namespace Evol.Util.Configuration
{
    public interface IStrongConfigurationProvider
    {
        bool TryGet<T>(out T value);

        IChangeToken GetReloadToken();

        void Load();
    }
}
