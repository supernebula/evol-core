using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.Utilities.Test.Extension
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void NotEqualTest()
        {
            var source = "service";
            var str = "service";
            var regex = new Regex(string.Format(@"^(?!{0}$)", str));
            var assert = regex.Match(source).Success;
            Trace.WriteLine("assert:" + assert);
            Assert.IsTrue(assert == (source != str));
        }
    }
}
