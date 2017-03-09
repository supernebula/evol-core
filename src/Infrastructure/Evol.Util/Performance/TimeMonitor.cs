using System;
using System.Diagnostics;

namespace Evol.Util.Performance
{
    public static class TimeMonitor
    {
        public static void Watch(string name, Action action, string format = "当前操作耗时，毫秒: {0}")
        {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();

            Trace.WriteLine(name);
            Trace.WriteLine(String.Format(format, sw.ElapsedMilliseconds));
        }


        public static void WatchLoop(string name, int loop, Action action, string format = "当前操作循环执行{1}次耗时，毫秒: {0}")
        {
            
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < loop; i++)
            {
                action.Invoke();
            }
            sw.Stop();
            Trace.WriteLine(name);
            Trace.WriteLine(String.Format(format, sw.ElapsedMilliseconds, loop));
        }


    }
}
