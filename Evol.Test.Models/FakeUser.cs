using System;
using Evol.Common;
using Evol.Utilities;

namespace Evol.Test.Model
{
    public class FakeUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public GenderType Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Points { get; set; }

        public float PersonHeight { get; set; }

        public DateTime Birthday { get; set; }

        public static FakeUser Fake()
        {
            return new FakeUser()
            {
                Id = Guid.NewGuid(),
                Username = FakeUtility.CreateUsername(6, 12),
                Password = FakeUtility.CreatePassword(6),
                RealName = FakeUtility.CreatePersonName(GenderType.None),
                Gender = (GenderType)FakeUtility.RandomInt(0, 2),
                Mobile = FakeUtility.CreateMobile(),
                Email = FakeUtility.CreateEmail(),
                Address = "测试地址",
                Points = FakeUtility.RandomInt(1, 200),
                PersonHeight = FakeUtility.CreatePersonHeight(),
                Birthday = FakeUtility.CreateBirthday(1980),
                CreateTime = DateTime.Now
            };
        }

    }
}
