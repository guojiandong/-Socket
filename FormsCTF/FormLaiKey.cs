using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF
{
    public partial class FormLaiKey : Form
    {
        public FormLaiKey()
        {
            InitializeComponent();
        }

        private void FormLaiKey_Load(object sender, EventArgs e)
        {
            LaiKey lk = new LaiKey();
            lk.Key = "1";
            lk.Lai = "2";
            bool isok= lk.Equals(lk);
            txtMSg.Text = isok.ToString();
        }
    }
    public class LaiKey : object
    {
        public string Lai { get; set; }
        public string Key { get; set; }
        public override bool Equals(object obj)
        {
            LaiKey lk = (LaiKey)obj;
            return lk.Lai == lk.Key;
        }
    }
}
