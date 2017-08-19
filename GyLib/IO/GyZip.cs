using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyLib.IO
{
    /// <summary>
    /// 文件压缩进度委托
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public delegate string de_FileSize(double count);
    /// <summary>
    /// 文件压缩 解压帮助类
    /// </summary>
    public class GyZip
    {
        #region 压缩文件夹下所有文件或者文件夹
        /// <summary>
        /// 压缩文件夹下所有文件或者文件夹
        /// </summary>
        /// <param name="strFile">需要压缩的文件夹的 全路径</param>
        /// <param name="strZip">压缩后存放的 全路径(包括压缩文件名.zip)</param>
        public void ZipFile(string strFile, string strZip, ref double count, de_FileSize de_fileSize = null)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
                strFile += Path.DirectorySeparatorChar;
            ZipOutputStream s = new ZipOutputStream(File.Create(strZip));
            s.SetLevel(6); // 0 - store only to 9 - means best compression

            zip(strFile, s, strFile, ref count, de_fileSize);
            s.Finish();
            s.Close();
        } 
        #endregion

        #region 遍历文件进行压缩
        /// <summary>
        /// 递归文件夹下是否有文件夹或者文件 并对文件进行压缩
        /// </summary>
        /// <param name="strFile">需要压缩的文件夹的 全路径</param>
        /// <param name="s"></param>
        /// <param name="staticFile">获取需要压缩文件的后部分路径</param>
        private void zip(string strFile, ZipOutputStream s, string staticFile, ref double count, de_FileSize de_fileSize = null)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar) strFile += Path.DirectorySeparatorChar;
            Crc32 crc = new Crc32();
            //获取所有文件或者子目录
            string[] filenames = Directory.GetFileSystemEntries(strFile);
            foreach (string file in filenames)
            {

                if (Directory.Exists(file))//如果存在文件夹继续递归
                {
                    zip(file, s, staticFile, ref count, de_fileSize);//递归
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    FileStream fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    //压缩文件
                    ZipEntry entry = new ZipEntry(tempfile);

                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;

                    count += buffer.Length;
                    if (de_fileSize != null)
                    {
                        de_fileSize(count);
                    }


                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);

                    s.Write(buffer, 0, buffer.Length);
                }
            }
        } 
        #endregion

        #region 解压文件
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="TargetFile">待解压的文件 (包括全路径.zip)</param>
        /// <param name="fileDir">解压后放置的目标目录 路径</param>
        /// <returns></returns>
        public string unZipFile(string TargetFile, string fileDir)
        {
            string rootFile = " ";
            try
            {
                //读取压缩文件(zip文件)，准备解压缩
                ZipInputStream s = new ZipInputStream(File.OpenRead(TargetFile.Trim()));
                ZipEntry theEntry;
                string path = fileDir;
                //解压出来的文件保存的路径

                string rootDir = " ";
                //根目录下的第一个子文件夹的名称
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    rootDir = Path.GetDirectoryName(theEntry.Name);
                    //得到根目录下的第一级子文件夹的名称
                    if (rootDir.IndexOf("\\") >= 0)
                    {
                        rootDir = rootDir.Substring(0, rootDir.IndexOf("\\") + 1);
                    }
                    string dir = Path.GetDirectoryName(theEntry.Name);
                    //根目录下的第一级子文件夹的下的文件夹的名称
                    string fileName = Path.GetFileName(theEntry.Name);
                    //根目录下的文件名称
                    if (dir != " ")
                    //创建根目录下的子文件夹,不限制级别
                    {
                        if (!Directory.Exists(fileDir + "\\" + dir))
                        {
                            path = fileDir + "\\" + dir;
                            //在指定的路径创建文件夹
                            Directory.CreateDirectory(path);
                        }
                    }
                    else if (dir == " " && fileName != "")
                    //根目录下的文件
                    {
                        path = fileDir;
                        rootFile = fileName;
                    }
                    else if (dir != " " && fileName != "")
                    //根目录下的第一级子文件夹下的文件
                    {
                        if (dir.IndexOf("\\") > 0)
                        //指定文件保存的路径
                        {
                            path = fileDir + "\\" + dir;
                        }
                    }

                    if (dir == rootDir)
                    //判断是不是需要保存在根目录下的文件
                    {
                        path = fileDir + "\\" + rootDir;
                    }

                    //以下为解压缩zip文件的基本步骤
                    //基本思路就是遍历压缩文件里的所有文件，创建一个相同的文件。
                    if (fileName != String.Empty)
                    {
                        FileStream streamWriter = File.Create(path + "\\" + fileName);

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }

                        streamWriter.Close();
                    }
                }
                s.Close();

                return rootFile;
            }
            catch (Exception ex)
            {
                return "1; " + ex.Message;
            }
        }
        #endregion

        #region 字节转换方法
        /// <summary>  
        /// 字节转换成{ "B", "KB", "MB", "GB", "TB", "PB" }方法  
        /// </summary>  
        /// <param name="size">字节值</param>  
        /// <returns></returns>  
        public string HumanReadableFilesize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];
        }
        #endregion
    }
}
