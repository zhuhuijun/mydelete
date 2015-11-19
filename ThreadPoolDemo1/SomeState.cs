using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolDemo1
{
    /// <summary> 这是用来保存信息的数据结构，将作为参数被传递
    /// </summary>
    public class SomeState
    {
        public int Cookie;
        public SomeState(int iCookie)
        {

            Cookie = iCookie;

        }
    }


}
