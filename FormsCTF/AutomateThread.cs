using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FormsCTF
{
    public  class AutomateThread
    {
        public static Thread StartNew(ThreadStart start)
        {
            Thread th = new Thread(start);
            th.Start();

            return th;
        }
        
    }
}
