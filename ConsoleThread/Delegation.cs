using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleThread
{
    public class Delegation
    {
        public Action _onBenMingNian;
        public event Action OnBenMingNian
        {
            add
            {
                this._onBenMingNian += value;
            }
            remove
            {
                this._onBenMingNian -= value;
            }
        }
        public int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
               if(value%12==0)
                {
                    if (this._onBenMingNian != null)
                    {
                        this._onBenMingNian();
                    }
                }
            }
        }
    }
}
