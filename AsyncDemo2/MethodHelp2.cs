using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo2
{
    public partial class MethodHelp
    {
        /// <summary>经结果通过委托进行返回
        /// </summary>
        /// <param name="callback"></param>
        public static void YBReturn(Action<string> callback)
        {
            //此处只说明有返回值情况  
            Task<int> t = new Task<int>(() =>
            {
                Thread.Sleep(2000);
                int sum = 0;
                Console.WriteLine("使用System.Threading.Tasks.Task执行异步操作.");
                for (int i = 0; i < 10; i++)
                {
                    sum = +i;
                }
                return sum;
            });
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            t.Start();
            //等待任务的完成执行过程。这里有两种方法，一种，使用已创建任务的Wait方法。会在这里形成阻塞
            // t.Wait();
            //【另一种不会形成阻塞的方法：使用已创建任务的ContinueWith方法。作用：任务完成后，再开启另外一个任务，对结果进行处理。】

            Task cwt = t.ContinueWith(m =>
            {
                Console.WriteLine("任务完成后的执行结果：{0}", m.Result.ToString());
                if (callback != null)
                {
                    callback(m.Result.ToString());
                }
            });
        }
        /// <summary>
        /// </summary>
        public static void Test()
        {
            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");
            names.ForEach(new Action<string>((s) =>
            {
                //这个是异步的
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(">>>>==>>>>：{0}", s);
                });
            }));
        }
    }
}
