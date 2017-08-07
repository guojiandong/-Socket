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

namespace FormsServer
{
    public partial class FormServer : Form
    {
        /// <summary>
        /// 将远程连接的客户端的IP地址和Socket存入集合中
        /// </summary>
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        public FormServer()
        {
            InitializeComponent();
            //线程开始的时候加这么一句
            Control.CheckForIllegalCrossThreadCalls = false;
            StartServer();
        }
        #region 在服务端创建一个负责监听IP地址跟端口号的Socket
        /// <summary>
        /// 在服务端创建一个负责监听IP地址跟端口号的Socket
        /// </summary>
        public void StartServer()
        {
            try
            {
                //服务端的IP地址
                IPAddress ip = IPAddress.Parse(txtIP.Text.Trim());
                //创建服务端的端口号对象
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text.Trim()));

                //当点击开始监听的时候 在服务端创建一个负责监听IP地址跟端口号的Socket
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketWatch.Bind(point);
                socketWatch.Listen(10);//监听
                ShowMsg("监听成功");

                //开启一个新线程执行Listen任务解决堵塞主线程
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketWatch);
            }
            catch { }

        }
        #endregion
        Socket socketSend;
       
        #region 等待客户端的连接 并且创建与之通信的Socket
        /// <summary>
        /// 等待客户端的连接 并且创建与之通信的Socket
        /// </summary>
        public void Listen(object o)
        {
            Socket socketWatch = o as Socket;
            //等待客户端的连接 并且创建一个负责通信的Socket
            //这里有一个问题：线程堵塞主线程一直等待客户端的连接？

            while (true)
            {
                try
                {
                    //Socket socketSend = socketWatch.Accept();
                    //负责跟客户端通信的Socket
                    socketSend = socketWatch.Accept();
                    //将远程连接的客户端的IP地址和Socket存入集合中
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    SelectClient.Items.Add(socketSend.RemoteEndPoint.ToString());
                    //默认选择第一项
                    SelectClient.SelectedIndex = 0;
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":连接成功");


                    string str = socketSend.RemoteEndPoint.ToString();
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    List<byte> list = new List<byte>();
                    list.Add(0);
                    list.AddRange(buffer);
                    //将泛型集合转成数组
                    byte[] newBuffer = list.ToArray();
                    socketSend.Send(newBuffer);//客户端连接IP地址和端口号发送给客户端
                    


                    //开启一个新的线程不停的接收客户端发来的消息
                    Thread th = new Thread(Recive);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch { }
            }
        }
        #endregion
        string key;
        /// <summary>
        /// 服务端不停的接收客户端发来的消息
        /// </summary>
        /// <param name="o"></param>
        public void Recive(object o)
        {
            //Socket socketSend = o as Socket;
            while (true)
            {
                 
                try
                {
                   //bool pp=  socketSend.Poll(10, SelectMode.SelectRead);
                
                    //客户端连接成功后 服务器应该接收客户端发来的信息
                    byte[] buffer = new byte[1024 * 1024];

                    //实际接收到的有效字节数据
                    int r = r = socketSend.Receive(buffer);//如果远程关闭抛异常
                    
                    if (r == 0)//如果客户端下线就跳出循环
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);
                    ClientOffLine(str);
                    ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                    
                }
                catch
                {
                    //bool ss = socketSend.Connected;
                    //key = socketSend.RemoteEndPoint.ToString();
                    //ShowMsg("客户端" + key + "已下线");
                    //////移除下线客户端
                    //SelectClient.Items.Remove(key);
                    
                    //////socketSend.Close();//不能这样关闭 否则无法访问已释放的对象
                    //////思路通过键值把Socket关闭，相互不影响
                    //dicSocket[key].Close();
                    //dicSocket.Remove(key);
                    //break;
                }
            }
        }
        /// <summary>
        /// 客户端离线
        /// </summary>
        public void ClientOffLine(string str)
        {
            string strr = str.Replace('\0',' ').Trim();
            bool isExstion = dicSocket.ContainsKey(strr);
            if(isExstion)
            {
                Socket c = dicSocket[strr];
                if (c != null)
                {
                    key = c.RemoteEndPoint.ToString();
                    SelectClient.Items.Remove(key);
                    dicSocket[key].Close();
                    dicSocket.Remove(key);
                }
            }
            
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

        private void btnListen_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        /// <summary>
        /// 服务端给客户端发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendContext_Click(object sender, EventArgs e)
        {
            string str = txtSendMsg.Text.Trim();
            byte[] buffer = Encoding.UTF8.GetBytes(str);

            List<byte> list = new List<byte>();
            list.Add(0);
            list.AddRange(buffer);
            //将泛型集合转成数组
            byte[] newBuffer = list.ToArray();

            //socketSend.Send(buffer);
            //获得用户在下拉框中选中的IP地址
            string ip = SelectClient.SelectedItem.ToString();
            dicSocket[ip].Send(newBuffer);
        }
        /// <summary>
        /// 选择要发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Admin\Desktop";
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();

            txtFile.Text = ofd.FileName;

        }
        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string point = SelectClient.SelectedItem.ToString();
            string path = txtFile.Text.Trim();
            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);

                byte[] newBuffer = list.ToArray();
                

                dicSocket[point].Send(newBuffer, 0, r+1,SocketFlags.None);
            }
        }
        /// <summary>
        /// 发送震动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZhenDong_Click(object sender, EventArgs e)
        {
            string point = SelectClient.SelectedItem.ToString();
            byte[] buffer = new byte[1];
            buffer[0] = 2;
            dicSocket[point].Send(buffer);
        }
        /// <summary>
        /// 检查一个Socket是否可连接  
        /// </summary>
        /// <param name="client"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private void IsSocketConnected(object client)
        {
            while (true)
            {
                try
                {
                    bool blockingState = socketSend.Blocking;

                    string host = socketSend.RemoteEndPoint.ToString();
                    string[] hostport = new string[2];
                    hostport = host.Split(':');
                    IPEndPoint point = new IPEndPoint(IPAddress.Parse(hostport[0]), Convert.ToInt32(hostport[1]));
                }
                catch (Exception)
                {
                    key = socketSend.RemoteEndPoint.ToString();
                    ShowMsg("客户端" + key + "已下线");
                    ////移除下线客户端
                    SelectClient.Items.Remove(key);

                    ////socketSend.Close();//不能这样关闭 否则无法访问已释放的对象
                    ////思路通过键值把Socket关闭，相互不影响
                    dicSocket[key].Close();
                    dicSocket.Remove(key);
                    throw;
                }
            }
        }
    }
}
