using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyLib.IO.FileHelper
{
    public static class GyFile
    {
        #region 获取应用程序各种目录
        /// <summary>
        /// 获取应用程序的当前工作目录
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDir()
        {
            return Path.Combine(Directory.GetCurrentDirectory());
        }
        /// <summary>
        /// 获取程序的基目录
        /// </summary>
        /// <returns></returns>
        public static string GetBaseDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// 获取模块的完整路径
        /// </summary>
        /// <returns></returns>
        public static string GetModuleDir()
        {
            return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        }
        /// <summary>
        /// 获取和设置当前目录(该进程从中启动的目录)的完全限定目录
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCompleteDir()
        {
            return Environment.CurrentDirectory;
        }
        /// <summary>
        /// 获取和设置包括该应用程序的目录的名称
        /// </summary>
        /// <returns></returns>
        public static string GetAppDirName()
        {
            return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }
        
        #endregion
        #region 创建一个新文件
        /// <summary>
        /// 使用File类的静态Create方法创建一个新文件
        /// </summary>
        /// <param name="path">新文件路径(包括后缀名)</param>
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        /// <summary>
        /// 使用File类的静态Create方法创建一个新文件 并添加内容
        /// </summary>
        /// <param name="path">新文件路径(包括后缀名)</param>
        /// <param name="context">文件内容</param>
        public static void CreateFile(string path, string context)
        {
            if (!File.Exists(path))
            {
                using (FileStream fS = File.Create(path))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(context);
                    fS.Write(buffer, 0, buffer.Length);
                    fS.Close();
                }
            }
        }
        /// <summary>
        /// 使用File类的静态Create方法创建一个新文件 并添加内容
        /// </summary>
        /// <param name="path">新文件路径(包括后缀名)</param>
        /// <param name="buffer">文件字节内容</param>
        public static void CreateFile(string path, byte[] buffer)
        {
            if (!File.Exists(path))
            {
                using (FileStream fS = File.Create(path))
                {
                    fS.Write(buffer, 0, buffer.Length);
                    fS.Close();
                }
            }
        }
        #endregion
        /// <summary>
        /// 复制一个文件
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        /// <param name="flag">是否覆盖现有的目标文件</param>
        public static void Copy(string srcPath,string destPath,bool flag=false)
        {
            if(File.Exists(srcPath))
            {
                File.Copy(srcPath, destPath, flag);
            }
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        public static void Move(string srcPath,string destPath)
        {
            if(!File.Exists(srcPath))
            {
                File.Move(srcPath, destPath);
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
                File.Delete(srcPath);
            }
        }
    }
}
