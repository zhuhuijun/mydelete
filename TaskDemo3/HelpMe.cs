using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo3
{
    /// <summary>辅助类
    /// </summary>
    public partial class HelpMe
    {
        /// <summary>父子任务
        /// </summary>
        public static void M1()
        {
            Task<string[]> parent = new Task<string[]>(state =>
            {
                Console.WriteLine(state);
                string[] result = new string[2];
                //创建并启动子任务
                new Task(() =>
                {
                    result[0] = "我是子任务1。";
                }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() =>
                {
                    result[1] = "我是子任务2。";
                }, TaskCreationOptions.AttachedToParent).Start();
                return result;
            }, "我是父任务，并在我的处理过程中创建多个子任务，所有子任务完成以后我才会结束执行。");
            //任务处理完成后执行的操作
            parent.ContinueWith(t =>
            {
                Array.ForEach(t.Result, r => Console.WriteLine(r));
            });
            //启动父任务
            parent.Start();
        }
    }
}
