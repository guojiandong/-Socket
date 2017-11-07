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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            btnStart.Click += BtnStart_Click;
            btnStop.Click += delegate (object sender, EventArgs e)
            {
                //w.Stop(th);
            };
            
        }
        Worker w = new Worker();
        Thread th = null;
        private  void BtnStart_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //if(th!=null)
            //{
            //    if (th.ThreadState == ThreadState.Suspended)
            //    {
            //        w.Run(th);
            //    }
            //}
            //else
            //{
            //    th = new Thread(() => {
            //        for (int i = 0; i < 10000; i++)
            //        {
            //            ShowTxtBox(txtContext, i.ToString());

            //        }
            //        //ShowDir(@"C:\Program Files\Microsoft SQL Server\100", tvDir.Nodes);
            //    });
            //    th.Name = "001";
            //    w.Run(th);
            //    txtMsg.Text = th.Name;
            //} 
            #endregion
            

        }
        public void ShowDir(string path,TreeNodeCollection tc)
        {
            //获得当前这一目录下所以文件夹的路径
            string[] dics = Directory.GetDirectories(path);
            for (int i = 0; i < dics.Length; i++)
            {
                //从文件夹的全路径中截取文件夹的名字
                string dicName = Path.GetFileNameWithoutExtension(dics[i]);

                //将文件夹的名字加载到节点集合下
                TreeNode tn = tc.Add(dicName);//获得节点

                ShowDir(dics[i], tn.Nodes);
            }
            string[] fileNames = Directory.GetFiles(path);
            for (int i = 0; i < fileNames.Length; i++)
            {
                TreeNode tn = tc.Add(Path.GetFileNameWithoutExtension(fileNames[i]));
                tn.Tag = fileNames[i];
            }
        }
        public void ShowTxtBox(TextBox txtBox,string msg)
        {
            if(txtBox.InvokeRequired)
            {
                txtBox.Invoke(new Action<String>((m) => {
                    Application.DoEvents();
                    txtBox.Text = m;
                }),msg);
            }
            else
            {
                txtBox.Text = msg;
            }
        }
    }
    public class Worker
    {
        #region 定义一个队列
        /// <summary>
        /// 定义一个队列，用于记录用户创建的线程
        /// 以便在窗体关闭的时候关闭所有用于创建的线程
        /// </summary>
        List<Thread> ThList = null;
        public Worker()
        {
            ThList = new List<Thread>();
        }
        #endregion
        #region 关闭所有线程
        /// <summary>
        /// 关闭所有线程
        /// </summary>
        public void Close()
        {
            if (ThList.Count > 0)
            {
                foreach (Thread th in ThList)
                {
                    th.Abort();
                }
            }
        }
        /// <summary>
        /// 根据线程名称关闭线程
        /// </summary>
        /// <param name="name"></param>
        public void Close(string name)
        {
            foreach (Thread th in ThList)
            {
                if (th.Name == name)
                {
                    th.Abort();
                }
            }
        }
        #endregion
        #region 启动线程
        /// <summary>
        /// 启动线程
        /// </summary>
        /// <param name="th"></param>
        public void Run(Thread th)
        {
            if (ThList.Count == 0)
            {
                ThList.Add(th);
            }
            else
            {
                foreach (Thread item in ThList)
                {
                    if (item.Name != th.Name)
                    {
                        ThList.Add(th);
                    }
                }
            }
            if (th.ThreadState == ThreadState.Suspended)
            {
                th.Resume();
            }
            else
            {
                th.Start();
            }
        }
        #endregion
        #region 停止线程
        /// <summary>
        /// 停止线程
        /// </summary>
        /// <param name="th"></param>
        public void Stop(Thread th)
        {
            if (th.IsAlive)
            {
                foreach (Thread item in ThList)
                {
                    if (th.Name == item.Name)
                    {
                        item.Suspend();
                    }
                }
            }
        } 
        #endregion

    }
}
