using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDemo1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ListView初始化
            this.lb.View = View.Details;
            this.lb.HeaderStyle = ColumnHeaderStyle.None;
            this.lb.FullRowSelect = true;
            this.lb.Columns.Add("");
            this.lb.Columns[0].Width = this.lb.Width - 24;

            init();
        }
        /// <summary>初始化数据
        /// </summary>
        public void init()
        {
            this.lb.Items.Insert(0, "出现如下错误：");
            this.lb.Items[0].ForeColor = Color.Red;
        }
        /// <summary> 开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Thread.Sleep(100);
                    this.lb.Invoke((MethodInvoker)
                    (() =>
                    {
                        this.lb.Items.Insert(0, "出现如下错误：" + i);
                        this.lb.Items[0].ForeColor = Color.Red;
                    }));
                });
            }
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Thread.Sleep(100);
                    this.lb.Invoke((MethodInvoker)
                    (() =>
                    {
                        this.lb.Items.Insert(0, "2出现如下错误：" + i);
                        this.lb.Items[0].ForeColor = Color.Red;
                    }));
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tcs = new TaskCompletionSource<int>();
            new Thread(() =>
            {
                Thread.Sleep(5000);
                int i = Enumerable.Range(1, 100).Sum();
                tcs.SetResult(i);
            }).Start();//线程把运行计算结果，设为tcs的Result。 
            Task<int> task = tcs.Task;
            this.lb.Invoke((MethodInvoker)
            (() =>
            {
                this.lb.Items.Insert(0, "2出现如下错误：" + task.Result);
                this.lb.Items[0].ForeColor = Color.Red;
            }));
        }

        private  void write(string msg)
        {
            this.lb.Invoke((MethodInvoker)
            (() =>
            {
                this.lb.Items.Insert(0, "2出现如下错误：" + msg);
                this.lb.Items[0].ForeColor = Color.Red;
            }));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Task<int> t3 = new Task<int>(FirstTask, 1);
            t3.Start();
            Task<int> t4 = t3.ContinueWith<int>(RecusiveTask);
            Task<int> t5 = t4.ContinueWith<int>(RecusiveTask);
            Task<int> t6 = t5.ContinueWith<int>(RecusiveTask).ContinueWith<int>(RecusiveTask);
        }

         public int FirstTask(object state)
        {
            int data = (int)state;
            for (int i = 0; i < data; i++)
            {
                Thread.Sleep(1000);
                write(string.Format("current thread {0} slept for {1} milisecond.", Task.CurrentId, (i + 1) * 100));
            }
            data++;
            return data;
        }

         public int RecusiveTask(Task<int> T)
        {
            int data = T.Result;
            for (int i = 0; i < data; i++)
            {
                Thread.Sleep(1000);
                write(string.Format("current thread {0} slept for {1} milisecond.", Task.CurrentId, (i + 1) * 100));
            }
            data++;
            return data;
        }

         private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             System.Environment.Exit(0);
         }
    }
}
