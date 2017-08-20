using GyLib;
using GyLib.IO.FileHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF
{
    public partial class frmFile : Form
    {
        public frmFile()
        {
            InitializeComponent();
            int[] ar = { 1 };
            myThrea my = new myThrea(ar);
            my.Labl = label1;
           
            new Thread(()=> {
                my.DoWork(1);
            }).Start();
        }
        #region MyRegion
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
        #endregion
    }
    public class myThrea : QueueThreadBase<int>
    {
        public Label Labl { get; set; }
        public myThrea(IEnumerable<int> collection) : base(collection)
        {
        }
        public override DoWorkResult DoWork(int pendingID)
        {
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    if(Labl.InvokeRequired)
                    {
                        Labl.Invoke(new Action<string>((n)=> {
                            Labl.Text = n;
                        }),i.ToString());
                    }
                    else
                    {
                        Labl.Text = i.ToString();
                    }
                }
                //..........多线程处理....
                return DoWorkResult.ContinueThread;//没有异常让线程继续跑..
            }
            catch (Exception)
            {
                return DoWorkResult.AbortCurrentThread;//有异常,可以终止当前线程.当然.也可以继续,
                //return  DoWorkResult.AbortAllThread; //特殊情况下 ,有异常终止所有的线程...
            }
            //return base.DoWork(pendingValue);
        }
    }
}
