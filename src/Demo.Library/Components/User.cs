using System;

namespace Demo.Library.Components
{
    public class User : IEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
