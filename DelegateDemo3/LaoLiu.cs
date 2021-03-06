﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo3
{
    /// <summary>异步的调用
    /// </summary>
    public class LaoLiu
    {
        /// <summary>
        /// 热水器类
        /// </summary>
        public Heater heater { private get; set; }

        //定义一个烧水的委托和委托变量
        private delegate int BoilWaterDelegate();
        private BoilWaterDelegate _dgBoilWater;

        public LaoLiu(Heater heater)
        {
            this.heater = heater;
            _dgBoilWater = new BoilWaterDelegate(heater.BoilWater);
        }

        /// <summary>
        /// 看电视
        /// </summary>
        public string WatchTv()
        {
            return "老刘去看电视了...\r\n";
        }

        /// <summary>
        /// 边吃饭边看电视
        /// </summary>
        /// <returns></returns>
        public string ListenToSong()
        {
            return "老刘去听音乐了...\r\n";
        }

        /// <summary>
        /// 开始烧水
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="stateObject"></param>
        /// <returns></returns>
        public IAsyncResult BeginBoilWater(AsyncCallback callBack, Object stateObject)
        {
            try
            {
                return _dgBoilWater.BeginInvoke(callBack, stateObject);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 烧水结束
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public int EndBoilWater(IAsyncResult ar)
        {
            if (ar == null)
                throw new NullReferenceException("IAsyncResult 参数不能为空");
            try
            {
                return _dgBoilWater.EndInvoke(ar);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// 打开热水器
        /// </summary>
        /// <param name="callback"></param>
        public void OpenHeater(Action<int> callback)
        {
            BeginBoilWater(BoilWaterCallBack, callback);
        }

        /// <summary>
        /// 烧水结束后显示当前的水温
        /// </summary>
        /// <param name="ar"></param>
        private void BoilWaterCallBack(IAsyncResult ar)
        {
            Action<int> callback = ar.AsyncState as Action<int>;
            int curtemp = EndBoilWater(ar);
            callback(curtemp);
        }
    }
}
