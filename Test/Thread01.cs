using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// 申明一个委托，表明需要在子线程上执行的方法的函数签名
    /// </summary>
    /// <param name="Diameter"></param>
    /// <returns></returns>
    delegate double CalculateMethod(double Diameter);
    public  class Thread01
    {
        public static void Mainn01()
        {
            ////通过ThreadStart委托告诉子线程讲执行什么方法,这里执行一个计算圆周长的方法
            ThreadStart threadStart = new ThreadStart(Calculate);

            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        public static void Calculate()
        {
            double Diameter = 0.5;
            Console.Write("The perimeter Of Circle with a Diameter of {0} is {1}",Diameter, Diameter * Math.PI);
        }


        static  CalculateMethod calcMethod = new CalculateMethod(Calculate);//把委托和具体的方法关联起来
        public static void Mainn02()
        {
            //此处开始异步执行,并且可以给出一个回调函数(如果不需要执行什么后续操作也可以不使用回调)
            calcMethod.BeginInvoke(5, new AsyncCallback(TaskFinished), null);
            Console.ReadLine();
        }
        /// <summary>
        /// 线程调用的函数,给出直径作为参数,计算周长
        /// </summary>
        /// <param name="Diameter"></param>
        /// <returns></returns>
        public static double Calculate(double Diameter)
        {
            return Diameter * Math.PI;
        }
        //线程完成之后回调的函数
        public static void TaskFinished(IAsyncResult result)
        {
            double re = 0;
            re = calcMethod.EndInvoke(result);
            Console.WriteLine(re);
        }


        public static void Mainn03()
        {
            //参数必须是object类型
            WaitCallback w = new WaitCallback(Calculate03);
            //下面启动四个线程,计算四个直径下的圆周长
            ThreadPool.QueueUserWorkItem(w, 1.0);
            ThreadPool.QueueUserWorkItem(w, 2.0);
            ThreadPool.QueueUserWorkItem(w, 3.0);
            ThreadPool.QueueUserWorkItem(w, 4.0);

            WaitCallback ww = new WaitCallback(addtest);
            ThreadPool.QueueUserWorkItem(ww, "Testaa");
        }
        public static void Calculate03(object Diameter)
        {
            
            Console.WriteLine( (double)Diameter * Math.PI);
        }
        private static  void addtest(object aa)
        {
            long result = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                result += i;
            }
            Console.WriteLine(result.ToString() + aa.ToString());

        }

        public static async Task<T> DelayResult<T>(T result,TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }
        public static async Task<string> DownloadStringWithRetries(string url)
        {
            using (var client = new HttpClient())
            {
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i !=3; i++)
                {
                    try
                    {
                        return await client.GetStringAsync(url);
                    }
                    catch
                    {

                    }
                    await Task.Delay(nextDelay);
                    nextDelay = nextDelay + nextDelay;

                }
                //最后一次重试
                return await client.GetStringAsync(url);
            }
        }
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static  string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/plain";

            //获取返回数据
            Stream getStream = request.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(getStream, Encoding.UTF8);
            string resultStr = sr.ReadToEnd();
            request.Abort();

            return resultStr;
        }
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static  string HttpPost(string message, string url)
        {
            //设置访问信息
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/plain";
            //封装数据
            request.ContentLength = buffer.Length;
            Stream requestStram = request.GetRequestStream();
            requestStram.Write(buffer, 0, buffer.Length);
            requestStram.Close();
            //获取返回数据
            Stream getStream = request.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(getStream, Encoding.UTF8);
            string resultStr = sr.ReadToEnd();
            request.Abort();

            return resultStr;
        }
    }
}
