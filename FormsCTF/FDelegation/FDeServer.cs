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

namespace FormsCTF.FDelegation
{
    public partial class FDeServer : Form
    {
        public FDeServer()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Client client = new FDelegation.Client();
            client.ReceiveMsg();


            Server ser = new FDelegation.Server();
            ser.SeverSendMsg(txtServerMsg.Text + "\r\n");
        }
    }
}
