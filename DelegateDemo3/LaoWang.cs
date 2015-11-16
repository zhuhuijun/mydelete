using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo3
{
    public class LaoWang
    {
        public Heater heater { get; set; }

        public LaoWang(Heater _heater)
        {
            this.heater = _heater;
        }
        /// <summary>打开热水器
        /// </summary>
        /// <returns></returns>
        public int OpenHeater()
        {
            return heater.BoilWater();
        }
        /// <summary>看电视
        /// </summary>
        /// <returns></returns>
        public string WatchTv()
        {
            return "老王去看电视了...\r\n";
        }

        /// <summary>
        /// 打开热水器
        /// </summary>
        /// <param name="callback"></param>
        public void OpenHeater(Action<int> callback)
        {
           // BeginBoilWater(BoilWaterCallBack, callback);
        }
    }
}
