using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyLib.IO.FileHelper
{
    public static class GyFileInfo
    {
        #region 获取应用程序的当前工作目录
        /// <summary>
        /// 获取应用程序的当前工作目录
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDir()
        {
            return Path.Combine(Directory.GetCurrentDirectory());
        } 
        #endregion
        #region 创建文件
        /// <summary>
        /// 使用FileInfo类的Create实例方法创建文件
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                new FileInfo(path).Create();
            }
        }
        /// <summary>
        /// 使用FileInfo类的Create实例方法创建文件 并添加内容
        /// </summary>
        /// <param name="path">文件路径(包括后缀名)</param>
        /// <param name="context">文件内容</param>
        public static void CreateFile(string path, string context)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = new FileInfo(path).Create())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(context);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
            }
        }
        #endregion
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        /// <param name="flag"></param>
        public static void CopyTo(string srcPath,string destPath,Boolean flag=false)
        {
            FileInfo fileInfo = new FileInfo(srcPath);
            fileInfo.CopyTo(destPath, flag);
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        public static void MoveTo(string srcPath, string destPath)
        {
            FileInfo fileInfo = new FileInfo(srcPath);
            if(!File.Exists(srcPath))
            {
                fileInfo.MoveTo(destPath);
            }
        }
        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="srcPath"></param>
        public static void Delete(string srcPath)
        {
            if(File.Exists(srcPath))
            {
                FileInfo fileInfo = new FileInfo(srcPath);
                fileInfo.Delete();
            }
        }
    }
}
