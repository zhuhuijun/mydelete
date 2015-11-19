﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>>>:Thread Pool Sample:");
            bool W2K = false;
            // 允许线程池中运行最多 10 个线程 
            int MaxCount = 10;
            // 新建 ManualResetEvent 对象并且初始化为无信号状态 
            ManualResetEvent eventX = new ManualResetEvent(false);
            Console.WriteLine(">>>>:Queuing {0} items to Thread Pool", MaxCount);
            // 注意初始化 oAlpha 对象的 eventX 属性 
            Alpha oAlpha = new Alpha(MaxCount);
            oAlpha.eventX = eventX;
            Console.WriteLine(">>>>:Queue to Thread Pool 0");
            try
            {
                // 将工作项装入线程池 
                // 这里要用到 Windows 2000 以上版本才有的 API，所以可能出现 NotSupp ortException 异常 
                ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta), new SomeState(0));
                W2K = true;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("These API's may fail when called on a non-Wind ows 2000 system.");
                W2K = false;
            }

            if (W2K) // 如果当前系统支持 ThreadPool 的方法. 
            {
                for (int iItem = 1; iItem < MaxCount; iItem++)
                {
                    // 插入队列元素 
                    Console.WriteLine("Queue to Thread Pool {0}", iItem);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta), new SomeState(iItem));
                }
                Console.WriteLine("Waiting for Thread Pool to drain");
                // 等待事件的完成，即线程调用 ManualResetEvent.Set() 方法 
                eventX.WaitOne(Timeout.Infinite, true);
                // WaitOne() 方法使调用它的线程等待直到 eventX.Set() 方法被调用 
                Console.WriteLine("Thread Pool has been drained (Event fired)");
                Console.WriteLine();
                Console.WriteLine("Load across threads");
                foreach (object o in oAlpha.HashCount.Keys)
                {
                    Console.WriteLine("{0} {1}", o, oAlpha.HashCount[o]);
                }
            }
            Console.ReadLine();
        }
    }
}
