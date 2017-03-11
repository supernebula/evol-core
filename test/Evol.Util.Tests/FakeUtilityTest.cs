using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.Common;

namespace Evol.Utilities.Test
{
    [TestClass]
    public class FakeUtilityTest
    {
        [TestMethod]
        public void CreatePersonNameTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var names = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var name = FakeUtility.CreatePersonName(GenderType.Female);
                names.Add(name);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var name in names)
            {
                Trace.WriteLine(name);
            }
        }

        [TestMethod]
        public void CreateEmailTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var emails = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var email = FakeUtility.CreateEmail();
                emails.Add(email);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in emails)
            {
                Trace.WriteLine(item);
            }
        }

        [TestMethod]
        public void CreateMobileTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var item = FakeUtility.CreateMobile();
                result.Add(item);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [TestMethod]
        public void CreateUsernameTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var item = FakeUtility.CreateUsername();
                result.Add(item);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [TestMethod]
        public void CreateGenderTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<GenderType>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtility.CreateGender();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [TestMethod]
        public void CreateBirthdayTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<DateTime>();
            for (int i = 0; i < 100; i++)
            {
                var date = FakeUtility.CreateBirthday(1970);
                result.Add(date);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item.ToString("yyyy-MM-dd"));
            }
        }


        [TestMethod]
        public void CreatePersonHeightTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<float>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtility.CreatePersonHeight();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [TestMethod]
        public void RandomBoolTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<bool>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtility.RandomBool();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }


        [TestMethod]
        public void CreatePasswordTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtility.CreatePassword();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }


        
    }
}
