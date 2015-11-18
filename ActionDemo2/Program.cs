using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                /*     HelperMe.Method(new Action<string>((s) =>
                     {
                         Action<string> ActionAsy = new Action<string>((a) => Console.WriteLine(">>>>:传入参数：{0}", a));
                         ActionAsy.BeginInvoke(s, resual => Console.WriteLine(">>>>:异步执行结束"), null);
                     }), i);*/

                // HelperMe.Method2(i);
                // yb(i);
                // tb(i);
                ybpara(i);
                tbpara(i);
            }
            Console.ReadLine();
        }
        /// <summary>异步
        /// </summary>
        /// <param name="age"></param>
        public static void yb(int age)
        {
            //异步执行 
            Func<string> FuncAsy = new Func<string>(() =>
            {
                people tPeo = new people("异步小李", age);
                return tPeo.ToString();
            }
            );
            FuncAsy.BeginInvoke(resual =>
            {
                //异步执行，从回调函数中获取返回结果
                Console.WriteLine(">>>>:{0}", FuncAsy.EndInvoke(resual));
                Console.WriteLine(">>>>:{0} end", age);
            }, null);
        }
        /// <summary>异步传参数
        /// </summary>
        /// <param name="age"></param>
        public static void ybpara(int age)
        {
            //异步执行 
            Func<people, string> FuncAsy = new Func<people, string>((pp) =>
            {
                return pp.Name;
            }
            );
            FuncAsy.BeginInvoke(new people("小李" + age, age), resual =>
            {
                //异步执行，从回调函数中获取返回结果
                Console.WriteLine(">>>>:{0}", FuncAsy.EndInvoke(resual));
                Console.WriteLine(">>>>:{0} end", age);
            }, null);
        }
        /// <summary>同步
        /// </summary>
        /// <param name="age"></param>
        public static void tb(int age)
        {
            Func<string> Func = new Func<string>(() =>
            {
                people tPeo = new people("同步小李", age);
                return tPeo.ToString();
            });
            //同步执行，获取返回结果
            Console.WriteLine(Func.Invoke());
        }
        /// <summary>同步传参
        /// </summary>
        /// <param name="age"></param>
        public static void tbpara(int age)
        {
            //同步执行 传入一个string，int类型的参数，返回一个people类型的结果
            Func<string, int, people> Func = new Func<string, int, people>((pName, pAge) =>
            {
                people tPeo = new people(pName, pAge);
                return tPeo;
            }
            );
            //同步执行，返回结果
            Console.WriteLine(Func.Invoke(">>>>:同步小李"+age, age).ToString());
        }
    }
}
