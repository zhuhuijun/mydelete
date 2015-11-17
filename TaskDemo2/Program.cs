using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskHelper.TaskM1();
            //TaskHelper.TaskM2();
            //TaskHelper.TaskM6();
            Task<int> t3 = new Task<int>(FirstTask, 9);
            t3.Start();
            Task<int> t4 = t3.ContinueWith<int>(RecusiveTask);
            Task<int> t5 = t4.ContinueWith<int>(RecusiveTask);
            Task<int> t6 = t5.ContinueWith<int>(RecusiveTask).ContinueWith<int>(RecusiveTask);  
            Console.ReadLine();
        }
        static public int FirstTask(object state)
        {
            int data = (int)state;
            for (int i = 0; i < data; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(string.Format("current thread {0} slept for {1} milisecond.", Task.CurrentId, (i + 1) * 100));
            }
            data++;
            return data;
        }

        static public int RecusiveTask(Task<int> T)
        {
            int data = T.Result;
            for (int i = 0; i < data; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(string.Format("current thread {0} slept for {1} milisecond.", Task.CurrentId, (i + 1) * 100));
            }
            data++;
            return data;
        }
    }
}
