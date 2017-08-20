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
    public partial class frmThread03 : Form
    {
        Thread th = null;
        public frmThread03()
        {
            InitializeComponent();
            this.th =
               new Thread(new ThreadStart(this.ThreadProcSafe));

            this.th.Start();

        }
        // 第一步：定义委托类型
        // 将text更新的界面控件的委托类型
        delegate void SetTextCallback(string text);

        //第二步：定义线程的主体方法
        /// <summary>
        /// 线程的主体方法
        /// </summary>
        private void ThreadProcSafe()
        {
            //...执行线程任务

            //在线程中更新UI（通过控件的.Invoke方法）
            for (int i = 0; i < 10000; i++)
            {
                this.SetText("This text was set safely.  "+i.ToString());
            }

            //...执行线程其他任务
        }
        //第三步：定义更新UI控件的方法
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            //如果调用控件的线程和创建创建控件的线程不是同一个则为True
            if (this.label1.InvokeRequired)
            {
                while (!this.label1.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.label1.Disposing || this.label1.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback((str)=> {
                    Application.DoEvents();//这句话放在委托方法里面就不会报异常  无法访问已释放的对象
                    this.label1.Text = str;
                });
                this.label1.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        }

    }
}
