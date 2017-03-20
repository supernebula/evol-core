using System;
using Evol.Common;
using Evol.Util;

namespace Evol.Test.Models
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
                Username = FakeUtil.CreateUsername(6, 12),
                Password = FakeUtil.CreatePassword(6),
                RealName = FakeUtil.CreatePersonName(GenderType.None),
                Gender = (GenderType)FakeUtil.RandomInt(0, 2),
                Mobile = FakeUtil.CreateMobile(),
                Email = FakeUtil.CreateEmail(),
                Address = "测试地址",
                Points = FakeUtil.RandomInt(1, 200),
                PersonHeight = FakeUtil.CreatePersonHeight(),
                Birthday = FakeUtil.CreateBirthday(1980),
                CreateTime = DateTime.Now
            };
        }

    }
}
