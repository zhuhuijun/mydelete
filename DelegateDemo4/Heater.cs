using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateDemo4
{
    public class Heater
    {
        /// <summary>设定温度
        /// </summary>
        public int SetTemp { get; set; }
        /// <summary>当前水温
        /// </summary>
        private int _currentTemp;

        public int CurrentTemp
        {
            get { return _currentTemp; }
        }
        /// <summary>是否停止
        /// </summary>
        private bool _flag;
        public bool Flag
        {
            get { return _flag; }

        }
        /// <summary>构造函数
        /// </summary>
        public Heater()
        {
            this._flag = false;
        }
        /// <summary>
        /// 烧水
        /// </summary>
        public int BoilWater()
        {
            //Thread.Sleep(5000);
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                _currentTemp = i;
                if (_currentTemp >= SetTemp)
                {
                    _flag = true;
                    break;
                }
            }
            return _currentTemp;
        }
    }
}
