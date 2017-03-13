using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Xunit;

namespace Evol.Utilities.Test.Extension
{
    public class RegexTest
    {
        [Fact]
        public void NotEqualTest()
        {
            var source = "service";
            var str = "service";
            var regex = new Regex(string.Format(@"^(?!{0}$)", str));
            var assert = regex.Match(source).Success;
            Trace.WriteLine("assert:" + assert);
            Assert.True(assert == (source != str));
        }
    }
}
