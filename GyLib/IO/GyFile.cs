using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyLib
{
    /// <summary>
    /// 文件操作帮助类
    /// </summary>
    public class GyFile
    {
        #region 属性
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public double FileSize { get; set; }
        /// <summary>
        /// 读写文件字节块的缓冲大小
        /// </summary>
        private byte[] buffer;
        /// <summary>
        /// 设置读写文件字节块的缓冲大小 默认2K
        /// </summary>
        public byte[] Buffer
        {
            get
            {
                if (buffer.Length==0) {
                    return new byte[2024];
                }
                else
                {
                    return buffer;
                }
            }
            set
            {
                buffer = value;
            }
        }
        /// <summary>
        /// 创建目录和子目录的实例方法
        /// </summary>
        public DirectoryInfo Dir{get ; set; }
        #endregion
        #region 使用递归获取文件夹中所有文件
        /// <summary>
        /// 使用递归获取文件夹中所有文件
        /// </summary>
        /// <param name="path">文件夹全路径</param>
        public void GetAllFile(string path)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(path);
            //GetDirectories()返回子目录
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                GetAllFile(NextFolder.FullName);
            }
            //GetFiles()返回当前目录的文件列表
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                //获取文件属性等
            }
        }
        #endregion
        #region 读取原文件数据并创建新文件及保存数据
        /// <summary>
        /// 读取原文件数据并创建新文件及保存数据
        /// </summary>
        /// <param name="readPath">原文件全路径</param>
        /// <param name="writePath">写入文件全路径</param>
        public void CreateFileWrite(string readPath, string writePath)
        {
            using (FileStream fsRead = new FileStream(readPath, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(writePath, FileMode.Create))
                {
                    int count = 0;//记录到底读取了多少字节的数据
                    while (fsRead.Position < fsRead.Length)
                    {
                        //每一次读取，。返回真正读取到的字节数，用count记录（最后一次读取后可能count可能会小于200）
                        count = fsRead.Read(buffer, 0, count);
                        //将数组中的数据写入到指定的文件
                        fsWrite.Write(buffer, 0, count);
                    }
                }
            }
        }
        #endregion
        #region 根据路径创建文件夹 和判断文件夹是否存在
        /// <summary>
        /// 根据路径创建文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public void CreateFolder(string path)
        {
            Dir = new DirectoryInfo(path);
            if (Dir.Exists)
            {

            }
            else
            {
                Dir.Create();
            }
        } 
        /// <summary>
        /// 判断文件夹是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Exists(string path)
        {
            Dir = new DirectoryInfo(path);
            if (Dir.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 获取文件夹中的文件总大小
        /// <summary>
        /// 获取文件夹中的文件总大小
        /// </summary>
        /// <param name="path">文件夹全路径</param>
        /// <param name="fileSize">文件总大小</param>
        public void GetFileSize(string path, ref double fileSize)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(path);
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                GetFileSize(NextFolder.FullName, ref fileSize);
            }
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                fileSize += NextFile.Length;
            }
        }
        /// <summary>
        /// 获取文件夹中的文件总大小 并返回
        /// </summary>
        /// <param name="path">文件夹全路径</param>
        /// <returns>返回文件总大小</returns>
        public double GetFileSize(string path)
        {
            double count = 0;
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                count = GetFileSize(dirs[i].FullName);
            }
            foreach (FileInfo NextFolder in dir.GetFiles())
            {
                count += NextFolder.Length;
            }
            return count;
        }
        #endregion
    }
}
