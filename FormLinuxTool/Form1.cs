using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FormLinuxTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {
            Guid newId = Guid.NewGuid();
            XmlHelp<LinuxFileDir> xml = new XmlHelp<LinuxFileDir>();
            xml.XMLFile = "LinuxFile.xml";
            Func<List<LinuxFileDir>, Dictionary<Guid, LinuxFileDir>> func = (lst) => {
                return lst.ToDictionary(x=>x.Id);
            };

            Dictionary<Guid, LinuxFileDir> dic = xml.GetDictionary(func);
            foreach (LinuxFileDir item in dic.Values)
            {
                if (item.Name == "176")
                {
                    newId = item.Id;
                }
            }

            LinuxFileDir lDir = new LinuxFileDir();
            lDir.Id = newId;
            lDir.Name = "176";
            lDir.Host = "111.231.220.206";
            lDir.User = "test";

            lDir.FileDirList = new List<FileDir>();
            string ls_path = @"G:\C#WorKAccumulate\并发编程\FormLinuxTool\bin\Debug";
            bool lb_isok = false;

            if (dic.ContainsKey(newId))//添加到相同Id中
            {
                foreach (LinuxFileDir item in dic.Values)
                {
                    if (item.Id == newId)
                    {
                        //判断是否有相同的路径
                        foreach (FileDir dir in item.FileDirList)
                        {
                            if (dir.Path == ls_path)
                            {
                                lb_isok = true;//有相同
                            }
                        }
                        if (lb_isok == false)//不相同则添加
                        {
                            lDir.FileDirList.AddRange(item.FileDirList);
                            lDir.FileDirList.Add(new FileDir() { Path = ls_path });

                        }
                        else
                        {
                            lDir.FileDirList.AddRange(item.FileDirList);
                        }
                    }
                }
                dic[newId] = lDir;
            }
            else//首次添加
            {
                lDir.FileDirList = new List<FileDir>() { new FileDir() { Path = ls_path } };
                dic.Add(newId, lDir);
            }
            xml.Save();
        }
    }
    public class LinuxFileDir
    {
        /// <summary>
        /// Linux常用日志文件目录信息Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Linux常用日志文件目录信息 服务器名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Linux常用日志文件目录信息 主机IP
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Linux常用日志文件目录信息 用户名
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Linux常用日志文件目录信息 路径
        /// </summary>
        public List<FileDir> FileDirList { get; set; }
    }
    public class FileDir
    {
        public string Path { get; set; }
    }
}
