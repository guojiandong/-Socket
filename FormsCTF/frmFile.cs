using GyLib.IO.FileHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF
{
    public partial class frmFile : Form
    {
        public frmFile()
        {
            InitializeComponent();
            
        }
        
        private void btnTestThread_Click(object sender, EventArgs e)
        {
            frmControl frmCtrl = new frmControl();
            frmCtrl.Show();
            //if(!frmCtrl.IsStop)//想通过委托在这里关闭？？？
            //{
            //    frmCtrl.Dispose();
            //}
            
        }

        private void btnTestThread02_Click(object sender, EventArgs e)
        {
            frmThread02 frm = new FormsCTF.frmThread02();
            frm.Show();
        }

        private void btnTestThread03_Click(object sender, EventArgs e)
        {
            frmThread03 frm = new FormsCTF.frmThread03();
            frm.Show();
        }

        private void btnTestThread04_Click(object sender, EventArgs e)
        {
            frmThread04 frm = new FormsCTF.frmThread04();
            frm.Show();
        }
    }
}
