using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Evol.Common;
using Evol.Util;

namespace Evol.Utilities.Test
{
    public class FakeUtilityTest
    {
        [Fact]
        public void CreatePersonNameTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var names = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var name = FakeUtil.CreatePersonName(GenderType.Female);
                names.Add(name);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var name in names)
            {
                Trace.WriteLine(name);
            }
        }

        [Fact]
        public void CreateEmailTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var emails = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var email = FakeUtil.CreateEmail();
                emails.Add(email);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in emails)
            {
                Trace.WriteLine(item);
            }
        }

        [Fact]
        public void CreateMobileTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var item = FakeUtil.CreateMobile();
                result.Add(item);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [Fact]
        public void CreateUsernameTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var item = FakeUtil.CreateUsername();
                result.Add(item);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [Fact]
        public void CreateGenderTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<GenderType>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtil.CreateGender();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [Fact]
        public void CreateBirthdayTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<DateTime>();
            for (int i = 0; i < 100; i++)
            {
                var date = FakeUtil.CreateBirthday(1970);
                result.Add(date);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item.ToString("yyyy-MM-dd"));
            }
        }


        [Fact]
        public void CreatePersonHeightTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<float>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtil.CreatePersonHeight();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }

        [Fact]
        public void RandomBoolTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<bool>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtil.RandomBool();
                result.Add(value);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var item in result)
            {
                Trace.WriteLine(item);
            }
        }


        [Fact]
        public void CreatePasswordTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var value = FakeUtil.CreatePassword();
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
