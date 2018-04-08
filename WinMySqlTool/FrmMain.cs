using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMySqlTool.Tools;

namespace WinMySqlTool
{
    public partial class FrmMain : Form
    {
        public static MySqlHelp mySql = new MySqlHelp();
        public FrmMain()
        {
            InitializeComponent();
            LoadDB();
        }
        public static string strCon = null;
        public void LoadDB()
        {
            // DataBase=wintop
            strCon = @"Host=localhost;Protocol=TCP;Port=3306;Pooling=true;Connection Lifetime=30;MAX Pool Size=512;Min Pool Size=50;User id=root;Password=123456;charset=gbk;Allow Zero Datetime=True;";
            mySql.strCon = strCon;
            List<string> listdb = mySql.GetDB();

            foreach (string item in listdb)
            {
                ListViewItem lvitem = lvRemoteDB.Items.Add(item);
                lvitem.Tag = item;
                lvitem.SubItems.Add(item);
            }
        }

        private void lvRemoteDB_Click(object sender, EventArgs e)
        {
           string dbName= lvRemoteDB.SelectedItems[0].Text;
            lvRemoteTable.Items.Clear();
            List<string> lTable = mySql.GetTableName(dbName);
            foreach (var item in lTable)
            {
                ListViewItem lvitem = lvRemoteTable.Items.Add(item);
                lvitem.Tag = item;
                lvitem.SubItems.Add(item);
            }
        }

        private void lvRemoteTable_Click(object sender, EventArgs e)
        {
            string table = lvRemoteTable.SelectedItems[0].Text;
            List<string> lField = mySql.GetField(table);
            foreach (var item in lField)
            {
                MessageBox.Show(item);
            }
        }
    }
}
