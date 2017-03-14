using System;
using Evol.Util;
using Evol.Common;

namespace Evol.Test.Model
{
    public class FakeOrder : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Recipient { get; set; }

        public double Amount { get; set; }

        public string Address { get; set; }

        public int Number { get; set; }

        public int Remark { get; set; }

        public static FakeOrder Fake()
        {
            return new FakeOrder() {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Recipient = FakeUtility.CreatePersonName(GenderType.None),
                Amount = FakeUtility.RandomDouble(10, 1000),
                Address = "测试地址",
                Number = FakeUtility.RandomInt(1, 10),
                CreateTime = DateTime.Now
            };
        }
    }
}
