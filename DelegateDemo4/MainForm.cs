using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateDemo4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>异步的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.lbText.AppendText("老刘想洗澡了...\r\n");
            Heater heater = new Heater();
            heater.SetTemp = 85;
            LaoWang laowang = new LaoWang(heater);
            laowang.OpenHeater(ActionCallBack);
            this.lbText.AppendText("老刘开始烧水...\r\n");
        }

        /// <summary>
        /// 烧水结束后显示当前的水温
        /// </summary>
        /// <param name="curTemp"></param>
        public void ActionCallBack(int curTemp)
        {
            this.lbText.Invoke((MethodInvoker)
             (() =>
             {
                 this.lbText.AppendText("水烧好了...\r\n");
                 this.lbText.AppendText("当前水温 " + curTemp.ToString() + " 度\r\n");
             }));
        }
    }
}
