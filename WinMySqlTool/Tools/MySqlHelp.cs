using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMySqlTool.Tools
{
    public class MySqlHelp
    {
        public  string strCon { get; set; }
        public  List<string> listDB = null;
        public List<string> listTable = null;

        public MySqlConnection GetCon()
        {
            if (strCon == null)
            {
                return null;
            }
            return new MySqlConnection(strCon);
        }

        public List<string> GetDB()
        {
            listDB = new List<string>();
            using (MySqlConnection con = GetCon())
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select SCHEMA_NAME from information_schema.SCHEMATA";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listDB.Add(reader["SCHEMA_NAME"].ToString());
                }
            }
            return listDB;
        }

        public List<string> GetTableName(string dbName)
        {
            // SELECT TABLE_NAME from information_schema.`TABLES` where TABLE_SCHEMA = 'wintop'
            listTable = new List<string>();
            using (MySqlConnection con = GetCon())
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TABLE_NAME from information_schema.`TABLES` where TABLE_SCHEMA = '"+dbName+"'";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listTable.Add(reader["TABLE_NAME"].ToString());
                }
            }
            return listTable;
        }

        public List<string> GetField(string table)
        {
            // select * from information_schema.COLUMNS where TABLE_NAME = 'appfiles_ftp'
            List<string> lfield = new List<string>();
            using (MySqlConnection con = GetCon())
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select COLUMN_NAME from information_schema.COLUMNS where TABLE_NAME = '" + table+"'";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lfield.Add(reader["COLUMN_NAME"].ToString());
                }
            }
            return lfield;

        }

    }
}
