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
        private void frmControl_Load(object sender, EventArgs e)
        {
            new Thread(() => {
                for (int i = 0; i < 10000; i++)
                {
                    SetLable(label1, i.ToString(),new dg((string str)=> {
                        label1.Text = str;
                    }));
                }
            }).Start();
        }
        public delegate void dg(string str);
        public void SetLable(object obj,string value,dg dglabl=null)
        {
            #region Label
            if (obj is Label)
            {
                Label labl = obj as Label;
                if (labl.InvokeRequired)
                {
                    //Delegate dgg = new dg((string str)=> {
                    //    labl.Text = str;
                    //});
                    if (dglabl != null)
                    {
                        Delegate dggg = new dg(dglabl);
                        labl.Invoke(dglabl, value);
                    }
                    else
                    {
                        labl.Invoke(new dg((string str) =>
                        {
                            labl.Text = str;
                        }), value);
                    }
                    //labl.Invoke(new Action<string>((string x) =>
                    //{
                    //    labl.Text = x;
                    //}), value);
                }
                else//主线程
                {
                    labl.Text = value;
                }
            }
            #endregion
            #region TextBox
            else if (obj is TextBox)
            {
                TextBox txtBox = obj as TextBox;
                if (txtBox.InvokeRequired)
                {
                    if (dglabl != null)
                    {
                        txtBox.Invoke(new dg(dglabl), value);
                    }
                    else
                    {
                        txtBox.Invoke(new Action<string>((str) =>
                        {
                            txtBox.Text = str;
                        }), value);
                    }
                }
                else
                {
                    txtBox.Text = value;
                }
            } 
            #endregion

        }
        private void frmControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
