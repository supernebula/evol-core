using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class UserQueryParameter
    {
        public string Key { get; set; }

        public string Mobile { get; set; }

        public string Username { get; set; }

        public SourcePlatformType Platform { get; set; }

        public string OpenId { get; set; }

    }
}
