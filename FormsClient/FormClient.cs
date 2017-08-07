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

namespace FormsClient
{
    public partial class FormClient : Form
    {
        bool startFlag = false;
        string ipPort;
        public FormClient()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
           // SocketConnect();
        }
        /// <summary>
        /// //当点击开始监听的时候 在服务端创建一个负责监听IP地址跟端口号的Socket
        /// </summary>
        Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(startFlag)
            {
                ShowMsg("正在连接服务器。。。。");
            }
            else
            {
                SocketConnect();
            }
            
        }
        #region 采用Socket方式，测试服务器连接 
        /// <summary> 
        /// 采用Socket方式，测试服务器连接 
        /// </summary> C#客户端连接服务器前先判断服务器连接是否正常
        /// <param name="host">服务器主机名或IP</param> 
        /// <param name="port">端口号</param> 
        /// <param name="millisecondsTimeout">等待时间：毫秒</param> 
        /// <returns></returns> 
        public bool TestConnection(string host, int port, int millisecondsTimeout)
        {
            millisecondsTimeout = 5;//等待时间
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(host, port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                EndPoint   hostPort = client.Client.RemoteEndPoint;

                
                //socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socketSend.Connect(hostPort);

                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Close();
            }
        }
        #endregion

        /// <summary>
        /// 检查一个Socket是否可连接  
        /// </summary>
        /// <param name="client"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool IsSocketConnected(Socket client,IPEndPoint point)
        {
            bool blockingState = client.Blocking;
            if (client.Connected == false)//判断是否连接服务器
            {
                while (true)//如果连接成功退出循环
                {
                    try
                    {
                        client.Connect(point);
                        return true;
                    }
                    catch { }
                    Thread.Sleep(200);
                }
            }
            else
            {
                return false;
            }
        }
        
        public void SocketConnect()
        {
            try
            {
                //服务端的IP地址
                IPAddress ip = IPAddress.Parse(txtIP.Text.Trim());
                //创建服务端的端口号对象
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text.Trim()));

                ////当点击开始监听的时候 在服务端创建一个负责监听IP地址跟端口号的Socket
                //socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socketSend.Connect(point);//连接成功后如果用户继续点击连接则回重新new Socket

                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state) {
                    //IsSocketConnected(socketSend, point);
                    if (socketSend.Connected == false)//判断是否连接服务器
                    {
                        startFlag = true;
                        while (true)//如果连接成功退出循环
                        {
                            try
                            {
                                socketSend.Connect(point);
                                break;
                            }
                            catch { }
                            Thread.Sleep(200);
                            ShowMsg("服务器没有启动：连接失败");
                        }
                    }
                    if (socketSend.Connected)
                    {
                        ShowMsg("服务器已经启动：连接成功");


                        byte[] buffer = new byte[1024 * 1024 * 5];
                        int r = socketSend.Receive(buffer);
                        if (r == 0)
                        {
                            
                        }
                        if (buffer[0] == 0)//文字消息
                        {
                            ipPort = Encoding.UTF8.GetString(buffer, 1, r);
                            ShowMsg(ipPort);
                        }

                        //开启一个新线程执行Listen任务解决堵塞主线程
                        Thread th = new Thread(Recive);
                        th.IsBackground = true;
                        th.Start();
                    }
                    else
                    {
                        ShowMsg("服务器没有启动：连接失败");
                    }
                }));
               
            }
            catch { }
        }
        /// <summary>
        /// 不停的接收服务端发来的消息
        /// </summary>
        public void Recive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024*1024*5];
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    if (buffer[0]==0)//文字消息
                    {
                        
                        string str = Encoding.UTF8.GetString(buffer, 1, r);
                        ShowMsg("\r\n"+socketSend.RemoteEndPoint.ToString() + ":" + str);
                    }
                    else if(buffer[0] == 1)//文件消息
                    {
                        SaveFileDialog ofd = new SaveFileDialog();
                        ofd.InitialDirectory = @"C:\Users\Admin\Desktop";
                        ofd.Title = "请选择要保存文件";
                        ofd.Filter = "所有文件|*.*";
                        ofd.ShowDialog(this);

                        string path = ofd.FileName;
                        using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fsWrite.Write(buffer, 1, r - 1);
                        }
                        MessageBox.Show("保存成功");
                    }
                    else if(buffer[0] == 2)
                    {
                        ZhenDong();
                    }
                    
                }
                catch { }
            }
        }
        public void ZhenDong()
        {
            for (int i = 0; i < 500; i++)
            {
                this.Location = new Point(200, 200);
                this.Location = new Point(280, 280);
            }
        }

        private void btnSendContext_Click(object sender, EventArgs e)
        {
            string str = txtSendMsg.Text.Trim();
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            socketSend.Send(buffer);
        }
        #region 显示信息到文本框中
        /// <summary>
        /// 显示信息到文本框中
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMsg(string msg)
        {
            txtContext.AppendText(msg + "\r\n");
        }
        #endregion

       
        /// <summary>
        /// 窗体关闭是发送消息告诉服务器我下线了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(ipPort);
            socketSend.Send(buffer);
            //socketSend.Close();
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            //socketSend.Close();
        }
        public void Exit()
        {
            socketSend.Close();
        }
    }
    #region 检查一个Socket是否可连接
    /// <summary>
    /// 检查一个Socket是否可连接  
    /// </summary>
    /// <param name="client"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    //private bool IsSocketConnected(Socket client, IPEndPoint point)
    //{

    //    bool blockingState = client.Blocking;
    //    if (client.Connected == false)//判断是否连接服务器
    //    {
    //        while (true)//如果连接成功退出循环
    //        {
    //            try
    //            {
    //                client.Connect(point);
    //                return true;
    //            }
    //            catch { }
    //        }
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //    //try
    //    //{
    //    //    byte[] tmp = new byte[1];
    //    //    client.Blocking = false;
    //    //    client.Send(tmp, 0, 0);
    //    //    return true;
    //    //}
    //    //catch (SocketException e)
    //    //{
    //    //    // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的  
    //    //    if (e.NativeErrorCode.Equals(10035))
    //    //        return false;
    //    //    else
    //    //        return true;
    //    //}
    //    //finally
    //    //{
    //    //    client.Blocking = blockingState;    // 恢复状态  
    //    //}
    //} 
    #endregion
}
