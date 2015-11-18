using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionDemo2
{
    public partial class HelperMe
    {
        /// <summary>Task的任务
        /// </summary>
        /// <param name="callback"></param>
        public static void Method(Action<string> callback, int j)
        {
            Task<int> t = new Task<int>(() =>
            {
                Thread.Sleep(2000);
                int sum = 0;
                Console.WriteLine(">>>>:ystem.Threading.Tasks.Task执行异步操作." + j);
                for (int i = 0; i < 10; i++)
                {
                    sum = +i;
                }
                sum = sum + j;
                Thread.Sleep(2000);
                Console.WriteLine(">>>>:" + j);
                return sum;
            });

            t.Start();
            Task wct = t.ContinueWith(m =>
            {
                Console.WriteLine("任务完成后的执行结果： {0}", m.Result.ToString());
                if (callback != null)
                {
                    callback(m.Result.ToString());
                }
            });
        }
        /// <summary>action的异步
        /// </summary>
        /// <param name="j"></param>
        public static void Method2(int j)
        {
            Action<int> async = new Action<int>((h) =>
            {
                Thread.Sleep(2000);
                Console.WriteLine(">>>>:" + h);
            });
            async.BeginInvoke(j, result =>
            {
                Console.WriteLine(">>>>:{0} have end", j);
            }, null);
        }
    }
}
