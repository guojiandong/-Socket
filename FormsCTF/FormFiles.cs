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
    public partial class FormFiles : Form
    {
        public FormFiles()
        {
            InitializeComponent();
        }

        private void FormFiles_Load(object sender, EventArgs e)
        {
            GetFi(@"D:\Folde");

           // FileSize(@"D:\Folde");
            
        }
        public long FileSize(string path)
        {
            long total = 0;
            DirectoryInfo dir = new DirectoryInfo(path);

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var item in dirs)
            {
                string str = item.FullName;
                total=FileSize(str);
            }
            foreach (FileInfo item in dir.GetFiles())
            {
                total += item.Length;
                txtMsg.Text += item.FullName + "  " + item.Length + "\r\n";
            }
            txtMsg.Text += total+ "\r\n";
            return total;
        }
        public long GetFi(string path)
        {
            long total = 0;
            string[] d = Directory.GetDirectories(path);
            foreach (var item in d)
            {
                total=GetFi(item);
            }

            string[] ps = Directory.GetFiles(path);
            foreach (var item in ps)
            {
                FileInfo fi = new FileInfo(item);

                total += fi.Length;
            }
            txtMsg.Text = total.ToString();
            return total;
        }

    }
}
