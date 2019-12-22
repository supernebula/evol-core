using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Evol.Util
{
    public static class TimeMonitor
    {
        public static void Watch(string name, Action action, Action<string> output = null,  string format = "当前操作耗时，毫秒: {0}")
        {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();

            if (output != null)
            {
                output.Invoke(name);
                output.Invoke(String.Format(format, sw.ElapsedMilliseconds));
                return;
            }

            Debug.WriteLine(name);
            Debug.WriteLine(String.Format(format, sw.ElapsedMilliseconds));
        }

        public static async Task WatchAsync(string name, Func<Task> action, Action<string> output = null, string format = "当前操作耗时，毫秒: {0}")
        {
            var sw = new Stopwatch();
            sw.Start();
            await action.Invoke();
            sw.Stop();

            if (output != null)
            {
                output.Invoke(name);
                output.Invoke(String.Format(format, sw.ElapsedMilliseconds));
                return;
            }

            Debug.WriteLine(name);
            Debug.WriteLine(String.Format(format, sw.ElapsedMilliseconds));
        }


        public static void WatchLoop(string name, int loop, Action action, Action<string> output = null, string format = "当前操作循环执行{1}次耗时，毫秒: {0}"
            )
        {
            
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < loop; i++)
            {
                action.Invoke();
            }
            sw.Stop();

            if (output != null)
            {
                output.Invoke(name);
                output.Invoke(string.Format(format, sw.ElapsedMilliseconds, loop));
                return;
            }

            Debug.WriteLine(name);
            Debug.WriteLine(string.Format(format, sw.ElapsedMilliseconds, loop));



        }


    }
}
