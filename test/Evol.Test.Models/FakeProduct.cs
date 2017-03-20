using Evol.Util;
using System;
using System.Collections.Generic;

namespace Evol.Test.Models
{
    public class FakeProduct : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Picture { get; set; }

        public string SourceUri { get; set; }

        public int Follows { get; set; }

        public string SourceSite { get; set; }

        public ProductStatusType Status { get; set; }

        public List<string> Specs { get; set; }

        public int VisitTotal { get; set; }

        public static FakeProduct Fake()
        {
            return new FakeProduct()
            {
                Id = Guid.NewGuid(),
                Title = "商品" + Guid.NewGuid().GetHashCode(),
                Description = string.Empty,
                Price = FakeUtil.RandomDouble(1, 1000),
                Picture = string.Empty,
                SourceUri = string.Empty,
                Follows = FakeUtil.RandomInt(1, 100),
                SourceSite = string.Empty,
                Status = (ProductStatusType)FakeUtil.RandomInt(0, 3),
                VisitTotal = FakeUtil.RandomInt(1, 10),
                CreateTime = DateTime.Now
            };
        }

    }


    public enum ProductStatusType
    {
        Normal = 0,

        SellOut = 1,

        OutOfStock = 2
    }


}
