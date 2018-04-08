using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleIIS
{
    class Program
    {
        private static bool isEndService;
        static Socket socketWatch = null;
        private static Thread threadWatch;

        static void Main(string[] args)
        {

            #region MyRegion
            // 创建Socket->绑定IP与端口->设置监听队列的长度->开启监听连接
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketWatch.Bind(new IPEndPoint(IPAddress.Any, 8080));
            socketWatch.Listen(10);
            // 创建Thread->后台执行
            threadWatch = new Thread(ListenClientConnect);
            threadWatch.IsBackground = true;
            threadWatch.Start(socketWatch);

            isEndService = false;

            Console.WriteLine("~_~消息:【您已成功启动Web服务！】");
            Console.ReadKey();
            #endregion

            #region MyRegion
            //Socket sersocket = new WorkerListen().socketListen;
            //while (true)
            //{
            //    Console.WriteLine("等着");
            //    WorkerAccept workerAccept = new WorkerAccept(sersocket);

            //    using (Socket s = workerAccept.socketAccept)
            //    {
            //        workerAccept.ShowAccept(s);
            //        workerAccept.Send();                }
            //}
            #endregion

            #region MyRegion
            ////Socket sersocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////sersocket.Bind(new IPEndPoint(IPAddress.Any, 8080));
            ////sersocket.Listen(2);
            //while (true)
            //{
            //    Console.WriteLine("等着");
            //    using (Socket s = sersocket.Accept())
            //    {
            //        string fstr;
            //        using (NetworkStream ns = new NetworkStream(s))
            //        {
            //            using (StreamReader sr = new StreamReader(ns))
            //            {
            //                fstr = sr.ReadLine();
            //                string line;
            //                while ((line = sr.ReadLine()) != null)
            //                {
            //                    Console.WriteLine(line);
            //                    if (line.Length <= 0)
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }


            //        string[] strs = fstr.Split(' ');
            //        string url = strs[1];
            //        Console.WriteLine("url=" + url);

            //        using (NetworkStream ns = new NetworkStream(s))
            //        {
            //            using (StreamWriter sw = new StreamWriter(ns))
            //            {
            //                string fp = @"D:\temp" + url;
            //                if (File.Exists(fp))
            //                {
            //                    sw.WriteLine("HTTP/1.1 200 OK");
            //                    sw.WriteLine();
            //                    string html = File.ReadAllText(fp);
            //                    sw.Write(html);
            //                }
            //                else
            //                {
            //                    sw.WriteLine("HTTP/1.1 404");
            //                    sw.WriteLine();
            //                    sw.WriteLine("没找到");
            //                }
            //            }
            //        }
            //    }
            //} 
            #endregion

        }

        private static void ListenClientConnect(object obj)

        {
            Socket socketListen = obj as Socket;

            while (!isEndService)
            {
                Socket proxSocket = socketListen.Accept();
                byte[] data = new byte[1024 * 1024 * 2];
                int length = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                // Step1:接收HTTP请求
                string requestText = Encoding.Default.GetString(data, 0, length);
                HttpContext context = new HttpContext(requestText);
                // Step2:处理HTTP请求
                HttpApplication application = new HttpApplication();
                application.ProcessRequest(context);
                //ShowMessage(string.Format("{0} {1} from {2}", context.Request.HttpMethod, context.Request.Url, proxSocket.RemoteEndPoint.ToString()));
                // Step3:响应HTTP请求
                proxSocket.Send(context.Response.GetResponseHeader());
                proxSocket.Send(context.Response.Body);
                // Step4:即时关闭Socket连接
                proxSocket.Shutdown(SocketShutdown.Both);
                proxSocket.Close();
            }

        }
    }
    public class HttpContext
    {
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }

        public HttpContext(string requestText)
        {
            Request = new HttpRequest(requestText);
            Response = new HttpResponse();
        }

    }
    public class HttpRequest
    {
        public HttpRequest(string requestText)
        {
            string[] lines = requestText.Replace("\r\n", "\r").Split('\r');
            string[] requestLines = lines[0].Split(' ');
            // 获取HTTP请求方式、请求的URL地址、HTTP协议版本
            HttpMethod = requestLines[0];
            Url = requestLines[1];
            HttpVersion = requestLines[2];
        }
        // 请求方式：GET or POST?
        public string HttpMethod { get; set; }
        // 请求URL
        public string Url { get; set; }
        // Http协议版本
        public string HttpVersion { get; set; }
        // 请求头
        public Dictionary<string, string> HeaderDictionary { get; set; }
        // 请求体
        public Dictionary<string, string> BodyDictionary { get; set; }
    }
    public class HttpResponse
    {
        // 响应状态码
        public string StateCode { get; set; }
        // 响应状态描述
        public string StateDescription { get; set; }
        // 响应内容类型
        public string ContentType { get; set; }
        //响应报文的正文内容
        public byte[] Body { get; set; }

        // 生成响应头信息
        public byte[] GetResponseHeader()
        {
            string strRequestHeader = string.Format(@"HTTP/1.1 {0} {1}
Content-Type: {2}
Accept-Ranges: bytes
Server: Microsoft-IIS/7.5
X-Powered-By: ASP.NET
Date: {3} 
Content-Length: {4}

", StateCode, StateDescription, ContentType, string.Format("{0:R}", DateTime.Now), Body.Length);

            return Encoding.UTF8.GetBytes(strRequestHeader);
        }

    }

    public interface IHttpHandler
    {
        void ProcessRequest(HttpContext context);
    }
    public class HttpApplication : IHttpHandler
    {
        // 对请求上下文进行处理
        public void ProcessRequest(HttpContext context)
        {
            // 1.获取网站根路径
            string bastPath = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = Path.Combine(bastPath + "\\MyWebSite", context.Request.Url.TrimStart('/'));
            string fileExtension = Path.GetExtension(context.Request.Url);
            // 2.处理动态文件请求
            if (fileExtension.Equals(".aspx") || fileExtension.Equals(".ashx"))
            {
                string className = Path.GetFileNameWithoutExtension(context.Request.Url);
                IHttpHandler handler = Assembly.Load("MyWebServer").CreateInstance("MyWebServer.Page." + className) as IHttpHandler;
                handler.ProcessRequest(context);

                return;
            }
            // 3.处理静态文件请求
            if (!File.Exists(fileName))
            {
                context.Response.StateCode = "404";
                context.Response.StateDescription = "Not Found";
                context.Response.ContentType = "text/html";
                string notExistHtml = Path.Combine(bastPath, @"MyWebSite\notfound.html");
                context.Response.Body = File.ReadAllBytes(notExistHtml);
            }
            else
            {
                context.Response.StateCode = "200";
                context.Response.StateDescription = "OK";
                context.Response.ContentType = GetContenType(Path.GetExtension(context.Request.Url));
                context.Response.Body = File.ReadAllBytes(fileName);
            }
        }

        // 根据文件扩展名获取内容类型
        public string GetContenType(string fileExtension)
        {
            string type = "text/html; charset=UTF-8";
            switch (fileExtension)
            {
                case ".aspx":
                case ".html":
                case ".htm":
                    type = "text/html; charset=UTF-8";
                    break;
                case ".png":
                    type = "image/png";
                    break;
                case ".gif":
                    type = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                    type = "image/jpeg";
                    break;
                case ".css":
                    type = "text/css";
                    break;
                case ".js":
                    type = "application/x-javascript";
                    break;
                default:
                    type = "text/plain; charset=gbk";
                    break;
            }
            return type;
        }
    }
    public class DemoPage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sbText = new StringBuilder();
            sbText.Append("<html>");
            sbText.Append("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>DemoPage</title></head>");
            sbText.Append("<body style='margin:10px auto;text-align:center;'>");
            sbText.Append("<h1>用户信息列表</h1>");
            sbText.Append("<table align='center' cellpadding='1' cellspacing='1'><thead><tr><td>ID</td><td>用户名</td></tr></thead>");
            sbText.Append("<tbody>");
            sbText.Append(GetDataList());
            sbText.Append("</tbody></table>");
            sbText.Append(string.Format("<h3>更新时间：{0}</h3>", DateTime.Now.ToString()));
            sbText.Append("</body>");
            sbText.Append("</html>");

            context.Response.Body = Encoding.UTF8.GetBytes(sbText.ToString());
            context.Response.StateCode = "200";
            context.Response.ContentType = "text/html";
            context.Response.StateDescription = "OK";
        }

        private string GetDataList()
        {
            StringBuilder sbData = new StringBuilder();
            //string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ToString();
            //using (SqlConnection conn = new SqlConnection(strConn))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT * FROM UserInfo";
            //        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            //        {
            //            DataTable dt = new DataTable();
            //            adapter.Fill(dt);

            //            if (dt != null)
            //            {
            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    sbData.Append("<tr>");
            //                    sbData.Append(string.Format("<td>{0}</td>", row["ID"].ToString()));
            //                    sbData.Append(string.Format("<td>{0}</td>", row["UserName"].ToString()));
            //                    sbData.Append("</tr>");
            //                }
            //            }
            //        }
            //    }
            //}

            return sbData.ToString();
        }
    }


    #region 监听类
    /// <summary>
    /// 监听类
    /// </summary>
    public class WorkerListen
    {
        public Socket socketListen = null;
        public WorkerListen()
        {
            if (socketListen == null)
            {
                socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketListen.Bind(new IPEndPoint(IPAddress.Any, 8080));
            }
            socketListen.Listen(10);
        }
        public void StartListen()
        {
            if (socketListen == null)
            {
                socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketListen.Bind(new IPEndPoint(IPAddress.Any, 8080));
            }
            socketListen.Listen(10);
        }
    }
    #endregion

    #region 接受信息及发送信息
    /// <summary>
    /// 接受信息及发送信息
    /// </summary>
    public class WorkerAccept
    {
        public Socket socketAccept = null;
        public WorkerAccept(Socket socketListen)
        {
            socketAccept = socketListen.Accept();
        }
        public void StartAccept(Socket socketListen)
        {
            socketAccept = socketListen.Accept();
        }

        public delegate string deAccept(Socket socketAccept);
        public string fstr;
        public string ShowAccept(Socket socketAccept)
        {
            using (NetworkStream ns = new NetworkStream(socketAccept))
            {
                using (StreamReader sr = new StreamReader(ns))
                {
                    fstr = sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        if (line.Length <= 0)
                        {
                            break;
                        }
                    }
                }
            }
            return fstr;
        }


        public void Send()
        {
            string[] strs = fstr.Split(' ');
            string url = strs[1];
            Console.WriteLine("url=" + url);

            using (NetworkStream ns = new NetworkStream(socketAccept))
            {
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string fp = @"D:\temp" + url;
                    if (File.Exists(fp))
                    {
                        sw.WriteLine("HTTP/1.1 200 OK");
                        sw.WriteLine();
                        string html = File.ReadAllText(fp);
                        sw.Write(html);
                    }
                    else
                    {
                        sw.WriteLine("HTTP/1.1 404");
                        sw.WriteLine();
                        sw.WriteLine("没找到");
                    }
                }
            }
        }
    } 
    #endregion
}
