using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionDemo1
{
    public partial class MethodHelp
    {
        private delegate void DisplayMessage(string message);

        /// <summary>使用委托的方式
        /// </summary>
        public static void MethodDelegate()
        {
            DisplayMessage messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
            Console.ReadLine();
        }
        /// <summary>使用Action的方式
        /// </summary>
        public static void MethodAction()
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
            Console.ReadLine();
        }
        /// <summary>匿名
        /// </summary>
        public static void MethodNoName()
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = delegate(string s) { ShowWindowsMessage(s); };
            else
                messageTarget = delegate(string s) { Console.WriteLine(s); };

            messageTarget("Hello, World!");
            Console.ReadLine();
        }

        /// <summary>Lambda
        /// </summary>
        public static void MethodLambda()
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = s => { ShowWindowsMessage(s); };
            else
                messageTarget = s => Console.WriteLine(s);

            messageTarget("Hello, World!");
            Console.ReadLine();
        }
        /// <summary>Foreach
        /// </summary>
        public static void MethodForeach()
        {
            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            // Display the contents of the list using the Print method.
            names.ForEach(Print);

            // The following demonstrates the anonymous method feature of C#
            // to display the contents of the list to the console.
            names.ForEach(delegate(String name)
            {
                Thread.Sleep(1000);
                Console.WriteLine(name);
            });
            names.ForEach(new Action<string>((s) =>
            {
                Thread.Sleep(1000);
                Print(s);
            }));
            names.ForEach(new Action<string>((s) =>
            {
                //这个是异步的
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Print(s+"sssss");
                });
            }));
            Console.ReadLine();
        }
        private static void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>打印
        /// </summary>
        /// <param name="s"></param>
        private static void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
