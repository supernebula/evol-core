using Evol.Common;
using Evol.Util;

namespace Evol.EntityFramework.Repository.Test.QueryEntries.Parameters
{
    public class UserQueryParameter
    {
        public string Username { get; set; }
        public string RealName { get; set; }
        public GenderType Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
    }
}
