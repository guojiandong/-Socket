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
    public partial class frmThread02 : Form
    {
        public frmThread02()
        {
            InitializeComponent();
            Worker();
        }
        static Thread ThProcess;
        public void Worker()
        {
            ThProcess = new Thread(new ThreadStart(ShowMsg));
            ThProcess.Start();
            
        }
        public void ShowMsg()
        {
            for (int i = 0; i < 10000; i++)
            {
                dgLabl(label1, i, new Action<int>((int n)=> {
                    Application.DoEvents();//这句话放在委托方法里面就不会报异常
                    label1.Text = n.ToString();
                }));
            }
        }
        public void dgLabl(Label lab,int msg,Action<int> dg_Labl)
        {
            if(lab.InvokeRequired)
            {
                lab.Invoke(dg_Labl,msg);
            }
            else
            {
                lab.Text = msg.ToString();
            }
        }
    }
}
