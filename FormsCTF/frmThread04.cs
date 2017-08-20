using FormsCTF.Tools;
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
    public partial class frmThread04 : Form
    {
        public frmThread04()
        {
            InitializeComponent();
        }
        #region 进度显示
        private int _index = 0;
        private int _count = 0;
        private int _percent = 0;
        private void IndexNext()
        {
            lock (this)
            {
                _index++;
            }
        }
        private void DisplayProgress()
        {
            if (_percent != _index * 100 / _count)
            {
                _percent = _index * 100 / _count;

                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    this.progressBar1.Value = _percent;
                }));

            }
        } 
        #endregion
        private void btnDanStart_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadStartMethod));
        }
        /// <summary>
        /// 用一个线程来启动
        /// </summary>
        /// <param name="arg"></param>
        public void ThreadStartMethod(object arg)
        {
            //初始化变量
            _index = 0;
            _count = 0;
            _percent = 0;

            int workcount = 50;
            _count = workcount * 100;

            //实例化多线程辅助类并启动
            ThreadMulti thread = new ThreadMulti(workcount);

            thread.WorkMethod = new ThreadMulti.DelegateWork(DoWork);//执行任务的函数
            thread.CompleteEvent = new ThreadMulti.DelegateComplete(WorkComplete);//所有任务执行完毕的事件
            thread.Start();
        }
        public void DoWork(int index, int threadindex)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                IndexNext();
            }
            DisplayProgress();
        }
        public void WorkComplete()
        {
            MessageBox.Show("ok");
        }
    }
}
