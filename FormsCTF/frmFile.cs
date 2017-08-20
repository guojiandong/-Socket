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

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取和设置包括该应用程序的目录的名称。
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            CreateFile(path+@".txt");
        }
        public void CreateFile(string path)
        {
            GyFile.CreateFile(path);
        }
    }
}
