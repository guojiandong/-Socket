using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Worker().StartMain();
            //new MyThread("").StartMain();
            //clsProxyConnection.Main("2001");

            //string path = @"D:\temp\pptvsetup_3.2.1.0076.exe";
            //string url = "http://download.pplive.com/pptvsetup_3.2.1.0076.exe";
            //DownLoad(url, path);
            ///http://www.rupeng.com/player.polyv.net/videos/player.swf
            //string path = @"D:\temp\player.swf";
            //string url = "http://www.rupeng.com/player.polyv.net/videos/player.swf";
            //DownLoad(url, path);


            //ScanDirectoryInfo();
            //DirectoryInfo theFolder = null;
            ////string path = @"D:\temp";
            //string path = @"D:\AEMRedis";
            //ScanInfo(theFolder,path );

            //SmsSend sms = new SmsSend();
            //sms.BeforeShow();
            //sms.ThreadPoolFnction();
            //sms.AfterShow();

            Hast dic = new Hast();
            dic.Set("1", "wwwww", 10);

            Console.ReadKey();
        }
        /// <summary>
        /// 文件下载保存
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="FileName"></param>
        public static void DownLoad(string Url,string FileName)
        {
            //使用WebClient
            //string url = "http://www.mozilla.org/images/feature-back-cnet.png";
            //WebClient myWebClient = new WebClient();
            //myWebClient.DownloadFile(url, "C:\\temp\\feature-back-cnet.png");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //远程服务器返回错误: (404) 未找到
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (!response.ContentType.ToLower().StartsWith("text/"))
            {
                //Value = SaveBinaryFile(response, FileName);
                byte[] buffer = new byte[1024];
                //创建文件保存文件
                Stream outStream = System.IO.File.Create(FileName);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }

        }
        static int count = 0;
       static  ArrayList temppath = new ArrayList();
        static  ArrayList finallypath = new ArrayList();
        static ArrayList lastpath = new ArrayList();
        /// <summary>
        /// 只能对某个文件夹进行遍历
        /// </summary>
        public static void ScanDirectoryInfo()
        {
            DirectoryInfo theFolder = new DirectoryInfo(@"D:\temp");
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();

            foreach (DirectoryInfo NextFolder in dirInfo)//遍历文件夹
            {
                FileInfo[] fileInfo = NextFolder.GetFiles();
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                {
                    if (Path.GetExtension(NextFile.ToString()) == ".exe")
                    {
                        temppath.Add(NextFile.FullName);
                        Console.WriteLine(NextFile.FullName);
                        count++;
                    }
                }
            }
            #region MyRegion
            //for (int i = 0; i < count; i++)
            //{
            //    string temp = temppath[i].ToString();
            //    int len = temp.Length;
            //    finallypath.Add(temppath[i].ToString().Substring(0, len - 4));
            //    lastpath.Add(finallypath[i] + ".jpg");
            //}
            //for (int i = 0; i < count; i++)
            //{
            //    File.Copy(temppath[i].ToString(), lastpath[i].ToString());
            //    File.Delete(temppath[i].ToString());
            //}
            //MessageBox.Show("转换完成！");
            #endregion
        }
        /// <summary>
        /// 自己实现文件遍历包括文件夹
        /// </summary>
        /// <param name="theFolder"></param>
        /// <param name="path"></param>
        public static void ScanInfo(DirectoryInfo theFolder, string path)
        {
            theFolder = new DirectoryInfo(@""+path+"");
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();//只能获取文件夹

            foreach (DirectoryInfo NextFolder in dirInfo)//只获取文件夹
            {
                ScanInfo(NextFolder, NextFolder.FullName);
            }

            FileInfo[] fileInfo = theFolder.GetFiles();//获取文件
            Console.WriteLine(theFolder.FullName);//获取文件夹目录
            foreach (FileInfo NextFile in fileInfo)  //遍历文件
            {
                bool ss = Path.GetExtension(NextFile.ToString()).Contains(".");
                if (ss)
                {
                    temppath.Add(NextFile.FullName);
                    Console.WriteLine(NextFile.FullName);
                    count++;
                }
            }
        }
        /// <summary>
        /// 将找到的文件和文件夹加载到节点上
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tc"></param>
        private void LoadDirectoryAndFile(string path, TreeNodeCollection tc)
        {
            //获得当前这一目录下所以文件夹的路径
            string[] dics = Directory.GetDirectories(path);
            for (int i = 0; i < dics.Length; i++)
            {
                //从文件夹的全路径中截取文件夹的名字
                string dicName = Path.GetFileNameWithoutExtension(dics[i]);

                //将文件夹的名字加载到节点集合下
                TreeNode tn = tc.Add(dicName);
                #region MyRegion
                //获得节点
                ////获取文件夹中所以文件全路径
                //string[] fileNames = Directory.GetFiles(dics[i]);
                //for (int j = 0; j < fileNames.Length; j++)
                //{
                //    tn.Nodes.Add( Path.GetFileNameWithoutExtension(fileNames[j]));
                //    //tn.Tag = fileNames[j];//记录全路径
                //    tn.Nodes[j].Tag = fileNames[j];
                //} 
                #endregion

                LoadDirectoryAndFile(dics[i], tn.Nodes);
            }
            string[] fileNames = Directory.GetFiles(path);
            for (int i = 0; i < fileNames.Length; i++)
            {
                TreeNode tn = tc.Add(Path.GetFileNameWithoutExtension(fileNames[i]));
                tn.Tag = fileNames[i];
            }
        }
    }
    public class Worker
    {
        /// <summary>
        /// 测试
        /// </summary>
        public void StartMain()
        {
            Worker worker = new Worker();
            Thread th = new Thread(worker.DoWork);


            th.Start();
            //主线程: 启动工作线程……
            Console.WriteLine("main thread: Starting worker thread...");

            // Loop until worker thread activates.
            //循环直到工作线程激活。
           while (!th.IsAlive) ;

            Thread.Sleep(1);


            // Request that the worker thread stop itself:
            //请求工作线程停止自身
            worker.RequestStop();

            // Use the Join method to block the current thread 
            // until the object's thread terminates.
            //直到对象的线程终止。
            th.Join();
            Console.WriteLine("main thread: Worker thread has terminated.");
        }
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("worker thread: working...");
            }
            //工作线程:优雅地终止
            Console.WriteLine("worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        private volatile bool _shouldStop;
    }
    public class MyThread
    {
        private string message;
        public MyThread(string data)
        {
            this.message = data;
        }
        public void ThreadMethod()
        {
            Console.WriteLine("Running in a thread, data: {0}", this.message);
        }

        public void StartMain()
        {
            var obj = new MyThread("info");
            Thread th = new Thread(obj.ThreadMethod);
            th.Start();
        }
    }

    public class SmsSend
    {
        public int ID { get; set; }
        public int Mobile { get; set; }
        /// <summary>
        /// 提示内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否已经发送
        /// </summary>
        public string HaveSend { get; set; }
        /// <summary>
        /// 保存时间
        /// </summary>
        public DateTime InsDate { get; set; }
        public int Count { get; set; }
        public DateTime LastErrorTime { get; set; }
        /// <summary>
        /// 要发送信息的集合
        /// </summary>
        public static List<SmsSend> SmsSendList { get; set; }
        static SmsSend()
        {
            SmsSendList = new List<SmsSend>()
            {
                new SmsSend() { ID=1,Mobile=10000,Content="内容",HaveSend="否"},
                new SmsSend() { ID=2,Mobile=10000,Content="内容",HaveSend="否" },
                new SmsSend() { ID=3,Mobile=10000,Content="内容",HaveSend="否" },
                new SmsSend() { ID=4,Mobile=10000,Content="内容",HaveSend="否" },
                new SmsSend() { ID=5,Mobile=10000,Content="内容",HaveSend="否" },
            };
        }
        public void Show(SmsSend sms)
        {
            Console.WriteLine(sms.ID.ToString()+"  "+sms.HaveSend);
        }
        public void BeforeShow()
        {
            Console.WriteLine("显示发送前数据信息");
            for (int i = 0; i < SmsSendList.Count; i++)
            {
                this.Show(SmsSendList[i]);
            }
        }
        public void AfterShow()
        {
            Console.WriteLine("显示发送后数据信息");
            for (int i = 0; i < SmsSendList.Count; i++)
            {
                this.Show(SmsSendList[i]);
            }
        }
        public  void VF_Send()
        {
            for (int i = 0; i < SmsSendList.Count; i++)
            {
                if (SmsSendList[i].HaveSend =="是")
                {

                }
                else
                {
                    SmsSendList[i].HaveSend = "是";
                }
                
            }
        }
        public void ThreadPoolFnction()
        {

            object ob = new object();
            Monitor.Enter(ob);//确保只能是一个线程访问
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj)=> {
                
                this.VF_Send();
            }));
            Monitor.Exit(ob);
            
            // 线程结束后执行后面的主线程代码 
            Console.WriteLine("结束了");

            
        }

        public SmsSend Selete(int id)
        {
            SmsSend sms = null;
            for (int i = 0; i < SmsSendList.Count; i++)
            {
                if(SmsSendList[i].ID==id)
                {
                    return sms = SmsSendList[i];
                }
                else
                {
                    return sms;
                }
            }
            return sms;
        }

    }

    public class Hast
    {
        Dictionary<string, string> dic;
        public int Set(string key,string value,int seond)
        {
            DateTime time = DateTime.Now;
            string str = time.Date.ToString("yyyy-MM-dd")+" "+ time.TimeOfDay.Hours+" "+ time.TimeOfDay.Minutes+" "+ time.TimeOfDay.Seconds;
            dic.Add(key, value + ":" + seond);
            return seond;
        }
        public string Get(string key)
        {
            string divValue=dic["key"];
            string[] arr = divValue.Split(':');
            return divValue;
        }
    }
}
