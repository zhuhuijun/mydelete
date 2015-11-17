using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            yb();
            Console.ReadLine();
        }
        /// <summary>同步执行
        /// </summary>
        static void tb()
        {

            new Action(async () =>
            {
                await Delay3000Async();
                await Delay2000Async();
                await Delay1000Async();
            })();
        }
        /// <summary>
        /// 异步
        /// </summary>
        static void yb()
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
        static async Task Delay3000Async()
        {
            await Task.Delay(3000);
            Console.WriteLine(3000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay2000Async()
        {
            await Task.Delay(2000);
            Console.WriteLine(2000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay1000Async()
        {
            await Task.Delay(1000);
            Console.WriteLine(1000);
            Console.WriteLine(DateTime.Now);
        }
    }
}
