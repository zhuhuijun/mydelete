using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDemo2
{
    /// <summary>用户实体
    /// </summary>
    public partial class people
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public people(string pName, int pAge)
        {
            this.Name = pName;
            this.Age = pAge;
        }
        public override string ToString()
        {
            return string.Format("名称叫{0}，年龄{1}", this.Name, this.Age);
        }
    }
}
