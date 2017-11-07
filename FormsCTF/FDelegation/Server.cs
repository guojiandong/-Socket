using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF.FDelegation
{
    public delegate void DeSendMsg(string sendMsg);
    public  class Server
    {
        //public TextBox txtServerMsg = null;
        public static event DeSendMsg deSendMsg;
        public void SeverSendMsg(string sendMsg)
        {
            if (deSendMsg != null)
            {
                deSendMsg(sendMsg);
            }
        }
    }
    public class Client
    {
        public TextBox txtClient = null;
        public void ReceiveMsg()
        {
            if (FDeClient.fDeClient == null)
            {
                FDeClient.fDeClient = new FDelegation.FDeClient();
                FDeClient.fDeClient.Show();
            }
            txtClient = FDeClient.fDeClient.txtClient;
            
            TxtShow("客户端接收消息\r\n");
            Server.deSendMsg += Server_deSendMsg;
        }

        private void Server_deSendMsg(string sendMsg)
        {
            TxtShow(sendMsg);
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
