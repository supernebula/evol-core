using System;
using System.Collections.Generic;
using System.Text;
using Evol.Util;
using Evol.Common;
using Xunit;
using Xunit.Abstractions;
using System.Linq;

namespace Demo.Tests
{
    public class EnumTest
    {
        private readonly ITestOutputHelper output;

        public EnumTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Fact]
        public void EnumSpecifyDescriptionTest()
        {
            var description = EnumHelper.GetDescription(GenderType.Male);
            output.WriteLine($"{GenderType.Male}：{description}");
        }

        [Fact]
        public void EnumAllDescriptionTest()
        {
            var valueDescriptionDic = EnumHelper.GetValueDescriptionDictionary<GenderType>();
            output.WriteLine($"Enum Value and Description:");
            foreach (var item in valueDescriptionDic)
            {
                output.WriteLine($"{item.Key}：{item.Value}");
            }

            var nameDescriptionDic = EnumHelper.GetNameDescriptionDictionary<GenderType>();
            output.WriteLine($"Enum Name and Description:");
            foreach (var item in nameDescriptionDic)
            {
                output.WriteLine($"{item.Key}：{item.Value}");
            }

        }
    }
}
