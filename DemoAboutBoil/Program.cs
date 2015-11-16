using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAboutBoil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("小文：将水壶放在炉子上");
            BoilingDelegate d = new BoilingDelegate(DelegateM.Boil);
            IAsyncResult result = d.BeginInvoke(DelegateM.BoilingFinishedCallback, null);
            Console.WriteLine("小文：开始整理家务...");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("小文：整理第{0}项家务...", i + 1);
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
    }
}
