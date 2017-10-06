using Evol.TMovie.Domain.Models.Values;
namespace Evol.TMovie.Manage.Models
{
    public class UserViewModel
    {
        public string OpenId { get; set; }

        public SourcePlatformType SourcePlatform { get; set; }

        public string Username { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
