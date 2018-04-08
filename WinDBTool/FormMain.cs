using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDBTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            ReaderDBName();
        }
        string connStr = @"Data Source=DESKTOP-Q7VHKSS\R2SQL;Initial Catalog=FitsDemo;Persist Security Info=True;User ID=sa;Password=123";
        private void btnConnectionDB_Click(object sender, EventArgs e)
        {
            //ReaderDBName();
        }
        public void ReaderDBName()
        {
            SerHelp help = new WinDBTool.SerHelp();
            help.strCon = connStr;
            SqlDataReader reader = help.Reader("SELECT Name FROM Master..SysDatabases ORDER BY Name");
           
            while (reader.Read())
            {
                string dbName = reader["Name"].ToString();
                ListViewItem lvitem = lvRemoteDB.Items.Add(dbName);
                lvitem.Tag = dbName;
                lvitem.SubItems.Add(dbName);
            }
        }
        public bool IsExetis(string dbName)
        {
            SerHelp help = new WinDBTool.SerHelp();
            help.strCon = connStr;
            SqlDataReader reader = help.Reader("SELECT Name FROM Master..SysDatabases ORDER BY Name");
            bool ok = false;
            while (reader.Read())
            {
                if (dbName == reader["Name"].ToString())
                {
                    ok= true;
                }
            }
            return ok;
        }
        public void ss()
        {
            //SqlConnection conn = new SqlConnection(connStr);
            //SqlConnection connn = new SqlConnection(connStr);


            //SqlCommand cmd = conn.CreateCommand();
            //conn.Open();
            //cmd.CommandText = "SELECT Name FROM Master..SysDatabases ORDER BY Name";
            //cmd.CommandType = CommandType.Text;
            //SqlDataReader reader=cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    string str = reader["Name"].ToString();
            //    if (connn.State == ConnectionState.Closed)
            //    {
            //        connn.Open();
            //    }

            //    SqlCommand cmdd = connn.CreateCommand();
            //    // SELECT Name FROM SysObjects Where XType='U' ORDER BY Name
            //    cmdd.CommandText = "SELECT Name FROM SysObjects Where XType='U' ORDER BY Name";
            //    SqlDataReader readerr = cmdd.ExecuteReader();
            //    while (readerr.Read())
            //    {
            //        string strr = readerr["Name"].ToString();

            //        //select* from sysobjects where xtype = 'u' and name = 't_test'
            //        //MessageBox.Show(strr);
            //        //SqlConnection connnn = new SqlConnection(connStr);
            //        //SqlCommand cmddd = connnn.CreateCommand();
            //        //connnn.Open();
            //        //cmddd.CommandText = "select * from "+strr;
            //        //SqlDataReader readerrr = cmddd.ExecuteReader();
            //        //int num = readerrr.FieldCount;
            //        //while (readerrr.Read())
            //        //{
            //        //    for (int i = 0; i < num; i++)
            //        //    {
            //        //        string s = readerrr[i].ToString();

            //        //        MessageBox.Show(s);
            //        //    }
            //        //}
            //    }
            //    readerr.Close();
            //}
        }

        private void tSMReaderRemoteDB_Click(object sender, EventArgs e)
        {
            if (lvRemoteDB.SelectedItems.Count > 0)
            {
                string dbName = lvRemoteDB.SelectedItems[0].Text;
                if (IsExetis(dbName))
                {
                    string sql = @"CREATE DATABASE ss   on  
                        primary  
                        (  
                        name = suntest_data,  
                        filename = 'e:\suntest_data.mdf',  
                        size = 3,  
                        maxsize = 10,  
                        filegrowth = 10%   
                        ),  
                        filegroup newgroup1  
                        (  
                        name = suntest_data,  
                        filename = 'e:\suntest_data.mdf',  
                        size = 3,  
                        maxsize = 10,  
                        filegrowth = 1 
                        )  
                        log on  
                        (  
                        name=suntest_log,  
                        filename='e:\suntest_log.mdf',  
                        size=1,  
                        maxsize=6,  
                        filegrowth=1 
                        )  ";
                    string cStr = @"Data Source=DESKTOP-Q7VHKSS\R2SQL;Persist Security Info=True;User ID=sa;Password=123";
                    SerHelp help = new SerHelp();
                    help.strCon = cStr;
                   int nu= help.Cmd(sql).ExecuteNonQuery();

                    MessageBox.Show("youx   " + nu);return;
                }

                {
                    string sql = @"SELECT Name FROM SysObjects Where XType='U' ORDER BY Name";
                    string cStr = @"Data Source=DESKTOP-Q7VHKSS\R2SQL;Initial Catalog=" + dbName
                        + ";Persist Security Info=True;User ID=sa;Password=123";
                    SerHelp help = new SerHelp();
                    help.strCon = cStr;
                    SqlDataReader reader = help.Reader(sql);
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string tableName = reader["Name"].ToString();
                        ListViewItem lvitem = listView1.Items.Add(tableName);
                        lvitem.Tag = tableName;
                        lvitem.SubItems.Add(tableName);
                    }
                };

            }
        }
    }
    
}
