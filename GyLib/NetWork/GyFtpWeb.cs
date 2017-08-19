using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GyLib
{
    /// <summary>
    /// 读取文件长度的百分比
    /// </summary>
    /// <param name="ai_Percent"></param>
    public delegate void dg_FTPprogress(int ai_Percent);
    /// <summary>
    /// FtpWeb文件传输协议帮助类
    /// </summary>
    public class GyFtpWeb
    {
        /// <summary>
        /// 登录名称  temp
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码  85557207xyz
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 实现文件传输协议（FTP）客户端  需要登录
        /// </summary>
        /// <param name="as_url">ftp服务器文件的全路径 ftp://gd.gysoft.cn/ye/AutoUploader.zip </param>
        /// <param name="as_Method">像ftp服务器发送的命令 </param>
        /// <param name="al_ContentLength"></param>
        /// <returns></returns>
        public FtpWebRequest of_GetFtpWebRequest(string as_url, string as_Method, long al_ContentLength = 0)
        {

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(as_url));
            reqFTP.UseBinary = true;// true，指示服务器要传输的是二进制数据；false，指示数据为文本。 默认值为 true。
            reqFTP.KeepAlive = false;//该值指定在请求完成之后是否关闭到 FTP 服务器的控制连接。
            reqFTP.Method = as_Method;//表示用于从FTP服务器下载文件的FTP RETR 协议方法
            reqFTP.UsePassive = true;// 默认是 true也就是被动模式，主动模式false


            if (al_ContentLength > 0)
            {
                //对于使用 DownloadFile 方法的请求，如果下载的文件包含数据，则属性大于零；如果下载的文件是空的，则属性为零
                reqFTP.ContentLength = al_ContentLength;
            }
            reqFTP.Credentials = new NetworkCredential(UserName, Password);


            return reqFTP;
        }

        /// <summary>
        /// 从ftp服务器中下载文件
        /// </summary>
        /// <param name="LocalfilePath">本地保存下载后的文件路径(包括全路径)</param>
        /// <param name="urlFtp">需要下载的文件路径(包括全路径)</param>
        /// <param name="fileName">需要下载的文件名和扩展名</param>
        /// <param name="al_fileLength">文件的总大小 可以为0</param>
        /// <param name="ab_ContinueDown">是否支持文件断点下载</param>
        /// <param name="a_FtpHint">委托实时监控文件读取的进度</param>
        /// <returns></returns>
        public string Download(string LocalfilePath, string urlFtp, string fileName, long al_fileLength, bool ab_ContinueDown = false, dg_FTPprogress a_FtpHint = null)
        {
            try
            {
                string ls_LocalFileName;
                if (LocalfilePath.IndexOf(".") < 0)  //如果只是一个目录
                {
                    if (!Directory.Exists(LocalfilePath))  //没有目录，则创建它
                    {
                        Directory.CreateDirectory(LocalfilePath);
                    }

                    if (!Directory.Exists(LocalfilePath))
                    {
                        return "目录不存在 " + LocalfilePath;
                    }

                    ls_LocalFileName = LocalfilePath + "\\" + Path.GetFileName(fileName);
                }
                else  //实际上是文件
                {
                    ls_LocalFileName = LocalfilePath;
                    string ls_path = Path.GetDirectoryName(ls_LocalFileName);
                    if (!Directory.Exists(ls_path))
                    {
                        Directory.CreateDirectory(ls_path);//创建文件
                    }
                    if (!Directory.Exists(ls_path))
                    {
                        return "目录不存在 " + ls_path;
                    }
                }
                //本地创建文件
                FileStream outputStream = new FileStream(ls_LocalFileName, FileMode.Create);

                //读取文件流
                FtpWebResponse response = (FtpWebResponse)of_GetFtpWebRequest(urlFtp, WebRequestMethods.Ftp.DownloadFile).GetResponse();

                Stream ftpStream = response.GetResponseStream();


                long li_total;
                if (al_fileLength <= 0)
                {
                    li_total = response.ContentLength;   //文件总的大小
                                                         //System.NotSupportedException当调用的方法不受支持时，或者当尝试读取、搜索或写入不支持所调用的功能的流时，就会引发 NotSupportedException 异常。
                }
                else
                {
                    li_total = al_fileLength;
                }

                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                long ll_HaveDownSzie = 0;
                //DownFileSize = li_total;

                if (ab_ContinueDown)
                {
                    ll_HaveDownSzie = outputStream.Length;
                    if (ll_HaveDownSzie > 0)  //断点下载
                    {
                        ftpStream.Seek(ll_HaveDownSzie, SeekOrigin.Begin);
                    }
                }

                int li_Percent = 0; //进度百分比
                readCount = ftpStream.Read(buffer, 0, bufferSize);//每次实际读取的长度
                while (readCount > 0)
                {
                    ll_HaveDownSzie += readCount;
                    if (a_FtpHint != null)
                    {
                        try
                        {
                            int li_NowPerCent;
                            li_NowPerCent = Convert.ToInt32(ll_HaveDownSzie * 100 / li_total);
                            if (li_Percent != li_NowPerCent)
                            {
                                li_Percent = li_NowPerCent;
                                a_FtpHint(li_Percent);
                            }
                        }
                        catch
                        {

                        }
                    }
                    //增加已经下载成功的大小
                    //DownFileNowLen = ll_HaveDownSzie;

                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                if (readCount > 0)
                {
                    ll_HaveDownSzie += readCount;
                    //增加已经下载成功的大小
                    //DownFileNowLen = ll_HaveDownSzie;
                }

                if (a_FtpHint != null)
                {
                    try
                    {
                        li_Percent = Convert.ToInt32(ll_HaveDownSzie * 100 / li_total);
                        a_FtpHint(li_Percent);//读取文件长度的百分比
                    }
                    catch
                    {

                    }
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "OK";
        }
    }
}