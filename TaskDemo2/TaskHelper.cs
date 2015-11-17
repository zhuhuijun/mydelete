using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo2
{
    public partial class TaskHelper
    {
        /// <summary>最原始的方法
        /// </summary>
        public static void TaskM1()
        {
            Task task1 = new Task(() => { Console.WriteLine(">>>>:this is old method"); });
            task1.Start();
        }

        /// <summary>最原始的方法
        /// </summary>
        public static void TaskM2()
        {
            Task.Run(() =>
            {
                Console.WriteLine(">>>>:this is sample method");
            });
        }
        /// <summary>任务等待
        /// </summary>
        public static void TaskM3_wait()
        {
            Task task3 = Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine(">>>>:this is wait method");
                    Thread.Sleep(5000);
                });
            Console.WriteLine(task3.IsCompleted);
            task3.Wait();
            Console.WriteLine(task3.IsCompleted);
        }
        /// <summary>返回值
        /// </summary>
        public static void TaskM4_return()
        {
            Task<int> task3 = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine(">>>>:this is wait method");
                return Enumerable.Range(1, 1000).Sum();
            });
            Console.WriteLine(task3.Result);
        }

        /// <summary>GetAwaiter
        /// </summary>
        public static void TaskM5()
        {
            Task<int> Task1 = Task.Run<int>(() => { return Enumerable.Range(1, 100).Sum(); });
            var awaiter = Task1.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Task1 finished");
                int result = awaiter.GetResult();
                Console.WriteLine(result); // Writes result 
            });
            Thread.Sleep(1000);
        }
        /// <summary>ContinueWith
        /// </summary>
        public static void TaskM6()
        {
            Task<int> Task1 = Task.Run<int>(() => { return Enumerable.Range(1, 100).Sum(); });
            Task1.ContinueWith(antecedent =>
            {
                Console.WriteLine(antecedent.Result);
                Console.WriteLine("Runing Continue Task");

                Task<int> task3 = Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine(">>>>:this is wait method");
                    return Enumerable.Range(1, 1000).Sum();
                });
                Console.WriteLine(task3.Result);

            });
            Thread.Sleep(1000);
        }
    }
}
