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
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();
        }
        public delegate void ObjControl
        private void frmControl_Load(object sender, EventArgs e)
        {
            new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    label1.Text = i.ToString();
                }
            }).Start();
        }
    }
}
