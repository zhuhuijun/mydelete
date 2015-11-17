using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo2
{
    public partial class MethodHelp
    {
        /// <summary>
        /// 异步
        /// </summary>
        public static void yb()
        {

            var task3 = Delay3000Async();
            var task2 = Delay2000Async();
            var task1 = Delay1000Async();

            new Action(async () =>
            {
                await task3;
                await task2;
                await task1;
            })();
        }
        /// <summary>Delay3000Async
        /// </summary>
        /// <returns></returns>
        static async Task Delay3000Async()
        {
            await Task.Delay(3000);
            Console.WriteLine(3000);
            Console.WriteLine(DateTime.Now);
        }
        /// <summary>Delay2000Async
        /// </summary>
        /// <returns></returns>
        static async Task Delay2000Async()
        {
            await Task.Delay(2000);
            Console.WriteLine(2000);
            Console.WriteLine(DateTime.Now);
        }
        /// <summary>Delay1000Async
        /// </summary>
        /// <returns></returns>
        static async Task Delay1000Async()
        {
            await Task.Delay(1000);
            Console.WriteLine(1000);
            Console.WriteLine(DateTime.Now);
        }
    }
}
