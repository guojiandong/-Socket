using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSoketServer
{
    public partial class FormServer : Form
    {
        #region 字段
        /// <summary>
        /// 客户端的网络结点 
        /// </summary>
        string RemoteEndPoint;     //客户端的网络结点  
        /// <summary>
        /// 负责监听客户端的线程  
        /// </summary>
        Thread threadwatch = null;//负责监听客户端的线程  
        /// <summary>
        /// 负责监听客户端的套接字
        /// </summary>
        Socket socketwatch = null;//负责监听客户端的套接字  
        //创建一个和客户端通信的套接字  
        Dictionary<string, Socket> dic = new Dictionary<string, Socket> { };   //定义一个集合，存储客户端信息 
        /// <summary>
        /// 保存ip
        /// </summary>
        private string ip = "127.0.0.1";
        /// <summary>
        /// 保存ip
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        /// <summary>
        /// 保存发送的ip
        /// </summary>
        private string sendIp { get; set; }

        private int setPort = 5555;
        /// <summary>
        /// 用来设置服务端监听的端口号
        /// </summary>
        public int SetPort
        {
            get { return setPort; }
            set { setPort = value; }
        }
        #endregion
        private string clientName;
        public FormServer()
        {
            InitializeComponent();
            ///线程开始的时候加这么一句
            Control.CheckForIllegalCrossThreadCalls = false;
            socketLoad();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            #region MyRegion
            ////1、如果有多个客户端连接怎么处理？
            ////2、如何选择某一个客户端进行发送信息？
            //int port = int.Parse(txtPort.Text.Trim());
            //string ip = txtIP.Text.Trim();
            //IPAddress ipe = IPAddress.Parse(ip);
            //IPEndPoint ipPort = new IPEndPoint(ipe, port);
            ////创建Socket服务
            //Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //// 通常每个套接字地址(协议/网络地址/端口)只允许使用一次。??
            //s.Bind(ipPort);
            //s.Listen(0);
            //txtContext.Text = "开始监听,等待客户端连接".MsgShow();


            //Socket c = null;
            //ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object statc) {
            //    //如果客户端关闭则关闭连接？？方便客户端重试连接
            //    c = s.Accept();
            //    txtContext.Text = "建立连接".MsgShow();

            //    try
            //    {
            //        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object stat) {

            //            string recStr = "";
            //            byte[] recBytes = new byte[1024];
            //            int bytes = c.Receive(recBytes, recBytes.Length, 0);

            //            recStr = Encoding.ASCII.GetString(recBytes, 0, bytes);
            //            recStr.MsgShow();
            //        }));

            //        string sendStr = txtSendMsg.Text.Trim();
            //        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
            //        c.Send(bs);


            //      bool connecionState= c.Poll(10, SelectMode.SelectRead);
            //        if(!connecionState)
            //        {
            //            "客户端连接断开".MsgShow();
            //        }

            //    }
            //    catch
            //    {

            //    }
            //    finally
            //    {
            //        c.Close();
            //        s.Close();
            //    }
            //})); 
            #endregion
            
        }
        public void socketLoad()
        {
            //定义一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接，Tcp协议）  
            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //服务端发送信息需要一个IP地址和端口号  
            IPAddress address = IPAddress.Parse(ip); //IP地址  
            IPEndPoint point = new IPEndPoint(address, SetPort);//绑定端口号  
            //此端口专门用来监听的  
            socketwatch.Bind(point); //监听绑定的网络节点  
            socketwatch.Listen(10);//将套接字的监听队列长度限制为20  
            threadwatch = new Thread(watchconnecting); //创建一个监听线程  
            threadwatch.IsBackground = true; //将窗体线程设置为与后台同步，随着主线程结束而结束  
            threadwatch.Start();

            //启动线程后 textBox3文本框显示相应提示 
            txtContext.Text = "启动线程";
        }
        #region 监听客户端发来的请求
        private void watchconnecting()
        {
            Socket connection = null;
            while (true)  //持续不断监听客户端发来的请求     
            {
                try
                {
                    connection = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    //textBox3.AppendText(ex.Message); //提示套接字监听异常     
                    break;
                }
                //获取客户端的IP和端口号  
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //让客户显示"连接成功的"的信息  
                string sendmsg = "欢迎咨询在线客服，本次由“国宇在线客服”为您解答，感谢您的支持！\r\n" + "本地IP:" + clientIP + "，本地端口" + clientPort.ToString();
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                connection.Send(arrSendMsg);//发送信息


                RemoteEndPoint = connection.RemoteEndPoint.ToString(); //客户端网络结点号  
                txtContext.Text = "成功与" + RemoteEndPoint + "客户端建立连接！\t\n".MsgShow(); //显示与客户端连接情况 
                dic.Add(RemoteEndPoint, connection);    //添加客户端信息  
                sendIp = RemoteEndPoint;
                //SelectClient.Text = sendIp;

                SelectClient.Items.Add(sendIp);
                SelectClient.SelectedIndex = 0;
                //OnlineList_Disp(RemoteEndPoint);    //显示在线客户端  

                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程      
                ParameterizedThreadStart pts = new ParameterizedThreadStart(recv);
                Thread thread = new Thread(pts);
                thread.IsBackground = true;//设置为后台线程，随着主线程退出而退出     
                //启动线程     
                thread.Start(connection);
            }
        }
        #endregion
        #region 接收信息
        ///客户端套接字对象  
        public void recv(object socketclientpara)
        {

            Socket socketServer = socketclientpara as Socket;
            while (true)
            {
                //创建一个内存缓冲区 其大小为1024*1024字节  即1M     
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区,并返回其字节数组的长度    
                try
                {
                    int length = socketServer.Receive(arrServerRecMsg);

                    //将机器接受到的字节数组转换为人可以读懂的字符串     
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);


                    //获取客户端的IP和端口号  
                    IPAddress clientIP = (socketServer.RemoteEndPoint as IPEndPoint).Address;
                    int clientPort = (socketServer.RemoteEndPoint as IPEndPoint).Port;

                    //让客户显示"连接成功的"的信息  
                    string sendmsg = "\r\n\n客户端IP:" + clientIP + "端口" + clientPort.ToString()+ "\r\n\n";

                    txtContext.Text += sendmsg;
                    txtContext.Text += clientName + " " + DateTime.Now.ToString() + "\r\n" + strSRecMsg + "\r\n\n";

                    this.txtContext.Focus();//获取焦点
                    this.txtContext.Select(this.txtContext.TextLength, 0);//光标定位到文本最后
                    this.txtContext.ScrollToCaret();//滚动到光标处
                }
                catch (Exception ex)
                {
                    //OnlineList.Remove(new clickInfo() { clickRemoteEndPoint = socketServer.RemoteEndPoint.ToString() });//从listbox中移除断开连接的客户端  
                    socketServer.Close();//关闭之前accept出来的和客户端进行通信的套接字  
                    break;
                }
            }
        }
        #endregion

        #region 发送
        public void send(string sendval)
        {
            string sendMsg = sendval;  //要发送的信息  
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendMsg);   //将要发送的信息转化为字节数组，因为Socket发送数据时是以字节的形式发送的  

            if (string.IsNullOrEmpty(sendIp))
            {
                throw new Exception("请选择要发送的客户端！");
            }
            else
            {
                dic[sendIp].Send(bytes);   //发送数据  
            }
        }
        #endregion
        #region 关闭
        public void ThreadAbort()
        {
            if (threadwatch != null)
            {
                threadwatch.Abort();
            }
        }
        #endregion
        private void btnSendContext_Click(object sender, EventArgs e)
        {
            sendIp = (string)SelectClient.SelectedItem;
            send(txtSendMsg.Text.Trim());
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFileName = ofd.FileName;

                using (FileStream fs = File.Open(strFileName, FileMode.Open))
                {
                    byte[] data = new byte[fs.Length];

                    int offset = 0;
                    int remaining = data.Length;
                    // 只要有剩余的字节就不停的读
                    while (remaining > 0)
                    {
                        //实际读到的长度
                        int read = fs.Read(data, offset, remaining);
                        if (read <= 0)
                            throw new EndOfStreamException("文件读取到" + read.ToString() + "失败！");

                        // 减少剩余的字节数
                        remaining -= read;
                        // 增加偏移量
                        offset += read;
                    }
                }
                //其他代码
            }
        }
    }
    public static  class StringHelper
    {
        public static void MsgShow(this string msg,TextBox txtBox)
        {
            txtBox.Text = msg;
        }
        public static string MsgShow(this string msg)
        {
            return msg;
        }
    }
}
