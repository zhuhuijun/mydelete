using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //有返回参数，func委托作为参数。有参数，有返回值
            Task<string> t = Task.Run<string>(() =>
            {
                //Func<TResult>委托
                string str = "有参任务";
                Thread.Sleep(3000);
                return str;
            });
            //开启另一个任务等待完成，并输出结果
            Task cwt = t.ContinueWith(m =>
            {
                Console.WriteLine("任务完成后的执行结果：{0}", m.Result.ToString());
                //Action<Task<TResult>>委托，m代表mycaller即调用者，在这里m=t.
            });
            MethodHelp.yb();
            MethodHelp.YBReturn(new Action<string>((s) =>
            {
                Console.WriteLine(">>>>回调行结果：{0}", s);
            }));
            MethodHelp.Test();
            Console.ReadLine();
        }

    }
}
