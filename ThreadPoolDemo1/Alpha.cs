using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo1
{
    /// <summary>Alpha
    /// </summary>
    public partial class Alpha
    {
        /// <summary>HashTable
        /// </summary>
        public Hashtable HashCount;
        /// <summary>信号灯
        /// </summary>
        public ManualResetEvent eventX;
        public static int iCount = 0;
        /// <summary>最大数量
        /// </summary>
        public static int iMaxCount = 0;
        /// <summary>构造函数
        /// </summary>
        /// <param name="MaxCount"></param>
        public Alpha(int MaxCount)
        {
            HashCount = new Hashtable(MaxCount);
            iMaxCount = MaxCount;
        }


        /// <summary> 线程池里的线程将调用 Beta()方法
        /// </summary>
        /// <param name="state"></param> 

        public void Beta(Object state)
        {
            // 输出当前线程的 hash 编码值和 Cookie 的值 
            Console.WriteLine(" {0} {1} :", Thread.CurrentThread.GetHashCode(), ((SomeState)state).Cookie);
            Console.WriteLine("HashCount.Count=={0}, Thread.CurrentThread.GetHash Code()=={1}", HashCount.Count,
                Thread.CurrentThread.GetHashCode());
            lock (HashCount)
            {
                // 如果当前的 Hash 表中没有当前线程的 Hash 值，则添加之 
                if (!HashCount.ContainsKey(Thread.CurrentThread.GetHashCode()))
                    HashCount.Add(Thread.CurrentThread.GetHashCode(), 0);
                HashCount[Thread.CurrentThread.GetHashCode()] = ((int)HashCount[Thread.CurrentThread.GetHashCode()]) + 1;
            }
            Thread.Sleep(2000);
            // Interlocked.Increment() 操作是一个原子操作，具体请看下面说明 
            Interlocked.Increment(ref iCount);
            if (iCount == iMaxCount)
            {
                Console.WriteLine();
                Console.WriteLine("Setting eventX ");
                eventX.Set();
            }
        }
    }
}
