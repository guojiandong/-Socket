using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    public  class Task01
    {
        public static void Mainn01()
        {
            using (ManualResetEvent m1 = new ManualResetEvent(false))
            using (ManualResetEvent m2 = new ManualResetEvent(false))
            {
                ThreadPool.QueueUserWorkItem(delegate {
                    suan01();
                    m1.Set();
                });
                ThreadPool.QueueUserWorkItem(delegate {
                    suan02();
                    m2.Set();
                });
                WaitHandle.WaitAll(new WaitHandle[] { m1, m2 });
            }
        }
        public static void suan01()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("suan01"+i.ToString());
            }
        }
        public static void suan02()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("suan02" + i.ToString());
            }
        }

        public static void Mainn02()
        {
            Task k1 = Task.Factory.StartNew(delegate { suan01(); });
            Task k2 = Task.Factory.StartNew(delegate { suan02(); });
            //k1.Wait();
            //k2.Wait();
            Task.WaitAll(k1,k2);
        }
        public static void Mainn03()
        {
            Task t1 = new Task(Method);
            t1.Start();
            Console.WriteLine("主线程代码运行结束");
            Console.ReadLine();
        }
        public static void Method()
        {
            throw new Exception("Task异常测试");
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(DateTime.Now.ToString());
            //    Thread.Sleep(1000);
            //}
        }
    }
}
