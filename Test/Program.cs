using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread01.Mainn03();
            //Task<string> str = Thread01.DownloadStringWithRetries("http://www.cnblogs.com/heyuquan/archive/2012/12/23/threadPool-manager.html");


            //string htmlStr = Thread01.HttpGet("http://www.cnblogs.com/heyuquan/archive/2012/12/23/threadPool-manager.html");


            Task<string> t1 = Task.Factory.StartNew(() => "测试");
            t1.Wait();
            Console.WriteLine(t1.Result);
           

            Task01.Mainn03();

            Console.ReadKey();
        }
    }
}
