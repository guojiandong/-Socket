using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDBTool
{
    /// <summary>
    /// sql server 数据库帮助类
    /// </summary>
    public  class SerHelp
    {
        public  string strCon { get; set; }
        public  SqlConnection Con()
        {
            return new SqlConnection(strCon);
        }
        public  SqlCommand Cmd(string sql)
        {
            SqlConnection con = Con();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            return cmd;
        }
        public  SqlDataReader Reader(string sql)
        {
            return Cmd(sql).ExecuteReader();
        }
    }
}
