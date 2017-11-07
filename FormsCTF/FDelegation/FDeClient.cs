using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF.FDelegation
{
    public partial class FDeClient : Form
    {
        public TextBox txtClient = null;
        public static FDeClient fDeClient = null;
        public FDeClient()
        {
            InitializeComponent();
            txtClient = txtClientMsg;
        }

        private void FDeClient_Shown(object sender, EventArgs e)
        {
            
            fDeClient = new FDelegation.FDeClient();
        }
    }
}
