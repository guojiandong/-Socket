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

        public void CreateFile(string path)
        {
            GyFile.CreateFile(path);
        }
    }
}
