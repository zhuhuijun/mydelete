using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAboutBoil
{
    /// <summary>委托的类型
    /// </summary>
    /// <returns></returns>
    internal delegate TimeSpan BoilingDelegate();
    public partial class DelegateM
    {
        /// <summary>符合委托的方法
        /// </summary>
        /// <returns></returns>
        public static TimeSpan Boil()
        {
            Console.Write("水壶:开始烧水了~~~~");
            Thread.Sleep(6000);
            Console.Write("水壶:水开了~~~~");
            return TimeSpan.MinValue;
        }
        /// <summary>回调结果的函数
        /// </summary>
        /// <param name="result"></param>
        public static void BoilingFinishedCallback(IAsyncResult result)
        {
            AsyncResult asyncResult = (AsyncResult)result;
            BoilingDelegate del = (BoilingDelegate)asyncResult.AsyncDelegate;
            del.EndInvoke(result);
            Console.WriteLine("小文：将热水灌到热水瓶");
            Console.WriteLine("小文：继续整理家务");

        }   
    }
}
