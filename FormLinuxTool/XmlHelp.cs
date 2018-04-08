using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FormLinuxTool
{
    public class XmlHelp<T>
    {
        public  Dictionary<Guid, T> dic;
        public string XMLFile { get; set; }

        #region 序列化XML文档
        /// <summary>
        /// 序列化XML文档
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  string XmlSerializerObject(object obj)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter tw = new StringWriter(sb))
            {
                XmlSerializer sz = new XmlSerializer(obj.GetType());
                sz.Serialize(tw, obj);
                return sb.ToString();
            }
        }
        #endregion

        #region 反序列化XML文档
        /// <summary>
        /// 反序列化XML文档
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public  object XmlDeSerializerObject(Type type, string xml)
        {
            try
            {
                using (StringReader tw = new StringReader(xml))
                {
                    XmlSerializer sz = new XmlSerializer(type);
                    return sz.Deserialize(tw);
                }
            }
            catch
            {
                return type.Assembly.CreateInstance(type.FullName);
            }
        }
        #endregion

        #region 获取所有字典中对应的 Linux常用日志文件目录信息
        /// <summary>
        /// 获取所有字典中对应的 Linux常用日志文件目录信息
        /// </summary>
        /// <returns></returns>
        public  Dictionary<Guid, T> GetDictionary(Func<List<T>,Dictionary<Guid,T>> func)
        {
            if (dic == null)
            {
                try
                {
                    List<T> lst = (List<T>)XmlDeSerializerObject(typeof(List<T>), File.ReadAllText(XMLFile));
                    //dic = lst.ToDictionary(x => x.Id);
                    dic = func(lst);
                }
                catch
                {
                    dic = new Dictionary<Guid, T>();
                }
            }
            return dic;
        }
        #endregion

        #region 保存字典中对应的 Linux常用日志文件目录信息
        /// <summary>
        /// 保存字典中对应的 Linux常用日志文件目录信息
        /// </summary>
        public  void Save()
        {
            List<T> list = new List<T>();
            foreach (T v in dic.Values)
                list.Add(v);

            string s = XmlSerializerObject(list);
            File.WriteAllText(XMLFile, s);
        }
        #endregion
        
    }
}
