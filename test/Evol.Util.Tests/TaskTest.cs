using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evol.Util.Tests
{
    class TaskTest
    {
        public async Task TaskWhenAllTest()
        {

            var task1 = Task.Run(() => {
                List<object> list = null;
                //list  = db.select();
                return list;
            });

            var task2 = Task.Run(() => {
                List<object> list2 = null;
                //list2  = db2.select();
                return list2;
            });


            var listArr = await Task.WhenAll(task1, task2);

            //listArr处理逻辑

        }

        public void TaskWhenAll2SyncTest()
        {
            var param1 = 0;
            var task1 = Task.Run(() => {
                List<object> list = null;
                //list  = db.select(param1);
                return list;
            });

            var task2 = Task.Run(() => {
                List<object> list2 = null;
                //list2  = db2.select();
                return list2;
            });



            var t = Task.WhenAll(task1, task2);
            t.Wait();
            var listArr = t.Result;

            //listArr处理逻辑

        }
    }
}
