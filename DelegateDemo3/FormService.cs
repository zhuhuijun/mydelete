using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateDemo3
{
    public partial class FormService : Form
    {
        public FormService()
        {
            InitializeComponent();
        }
        /// <summary>同步调用的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTB_Click(object sender, EventArgs e)
        {
            this.tbTB.AppendText("老王想洗澡了...\r\n");
            Heater heater = new Heater();
            heater.SetTemp = 70;
            LaoWang laowang = new LaoWang(heater);
            this.tbTB.AppendText("老王打开了热水器...\r\n");
            int curTemp = laowang.OpenHeater();
            //这里阻塞了
            this.tbTB.AppendText(laowang.WatchTv());
            if (laowang.heater.Flag)
            {
                this.tbTB.AppendText("水烧好了...");
                this.tbTB.AppendText("当前水温 " + curTemp.ToString() + " 度");
            }
        }
        /// <summary>异步按钮的调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYB_Click(object sender, EventArgs e)
        {
            this.tbYB.AppendText("老刘想洗澡了...\r\n");
            Heater heater = new Heater();
            heater.SetTemp = 85;
            LaoLiu laoliu = new LaoLiu(heater);
            this.tbYB.AppendText("老刘开始烧水...\r\n");
            IAsyncResult ar = laoliu.BeginBoilWater(null, null);
            //ar.AsyncWaitHandle.WaitOne(2000);
            this.tbYB.AppendText(laoliu.WatchTv());
            this.tbYB.AppendText(laoliu.ListenToSong());
            /*       int i = 0;
                   //轮询判断异步是否完成
                   while (!ar.IsCompleted)
                   {
                       i++;
                       this.tbYB.AppendText(" " + i.ToString() + " ");
                       if (ar.IsCompleted)
                       {
                           this.tbYB.AppendText("\r\n水烧好了...\r\n");
                       }
                   }
                   int curTemp = laoliu.EndBoilWater(ar);

                   this.tbYB.AppendText("当前水温 " + curTemp.ToString() + " 度");*/



            //WaitOne 作用 等待句柄
            bool flag = true;
            while (flag)
            {
                this.tbYB.AppendText(string.Format("老刘去看了一眼,水还没烧好,当前水温 {0} 度...\r\n", heater.CurrentTemp));
                flag = !ar.AsyncWaitHandle.WaitOne(1000);
            }
            this.tbYB.AppendText("水烧好了...\r\n");
            int curTemp = laoliu.EndBoilWater(ar);
            this.tbYB.AppendText("当前水温 " + curTemp.ToString() + " 度");
        }
        /// <summary>第二个异步调用的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnyb2_Click(object sender, EventArgs e)
        {
            this.tbYB2.AppendText("老刘想洗澡了...\r\n");
            Heater heater = new Heater();
            heater.SetTemp = 85;
            LaoLiu laoliu = new LaoLiu(heater);
            this.tbYB2.AppendText("老刘开始烧水...\r\n");
            //老刘打开热水器，然后去看电视了
            laoliu.OpenHeater(ActionCallBack);
            this.tbYB2.AppendText(laoliu.WatchTv());
            this.tbYB2.AppendText(laoliu.ListenToSong());
        }
        /// <summary>
        /// 烧水结束后显示当前的水温
        /// </summary>
        /// <param name="ar"></param>
        public void ActionCallBack(int curTemp)
        {
            this.tbYB2.Invoke((MethodInvoker)
             (() =>
             {
                 this.tbYB2.AppendText("水烧好了...\r\n");
                 this.tbYB2.AppendText("当前水温 " + curTemp.ToString() + " 度");
             }));
        }
    }
}
