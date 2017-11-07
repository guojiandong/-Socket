using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF
{
    public partial class FTextBox : Form
    {
        public FTextBox()
        {
            InitializeComponent();

        }
        delegate void deShow(int num);
        private void FTextBox_Load(object sender, EventArgs e)
        {
            Client client1 = new Client();
            new Thread(() => {
                client1.txtClient = txtMsg;
                client1.ReceiveMsg();

                Client client2 = new Client();
                client2.txtClient = txtClient2;
                client2.ReceiveMsg();

            }).Start();

        }
        public void tShow(int num)
        {
            if (txtMsg.InvokeRequired)
            {
                txtMsg.Invoke(new deShow(tShow), num);
            }
            else
            {
                txtMsg.Text += "hello word" + num + "\r\n";
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server server1 = new Server();
            new Thread(()=> {
                server1.SendMsg(txtServer.Text);
            }).Start();
        }
    }
    /// <summary>
    /// 定义发送消息委托
    /// </summary>
    /// <param name="msg"></param>
    public delegate void DeSendMsg(string msg);
    /// <summary>
    /// 发送消息服务器
    /// </summary>
    public class Server
    {
        /// <summary>
        /// 声明发送消息事件
        /// </summary>
        public static event DeSendMsg deSendMsg;
        /// <summary>
        /// 服务器发送消息
        /// </summary>
        /// <param name="msg"></param>
        public  void SendMsg(string msg)
        {
            //如果客户端注册了把服务器即可收到服务器发送的消息
            if (deSendMsg != null)
            {
                deSendMsg(msg);
            }
        }
    }
    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {
        public TextBox txtClient = null;
        /// <summary>
        /// 客户端接收消息
        /// </summary>
        public void ReceiveMsg()
        {
            TxtShow("客户端收到信息\r\n");
            //客户端注册服务器事件接收消息
            Server.deSendMsg += Client_deSendMsg;
        }

        /// <summary>
        /// 客户端接收服务器发送的消息
        /// </summary>
        /// <param name="msg"></param>
        private void Client_deSendMsg(string msg)
        {
            TxtShow("服务器发送的信息： " + msg + "\r\n");
        }
        public void TxtShow(string receiveMsg)
        {
            if (txtClient.InvokeRequired)
            {
                txtClient.Invoke(new Action<string>(TxtShow), receiveMsg);
            }
            else
            {
                txtClient.Text += receiveMsg;
            }
        }
    }
}
