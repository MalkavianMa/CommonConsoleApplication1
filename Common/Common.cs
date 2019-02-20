using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Net.Sockets;

namespace Malkavian
{
    #region 公共类M
    /// <summary>
    /// 公共类
    /// </summary>
    public class Common
    {

        /// <summary>
        /// 
        /// </summary>
        public Common()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlPath"></param>
        public Common(string xmlPath)
        {

        }

        /// <summary>
        /// 当前时间yyyy-MM-dd HH:mm:ss.fff
        /// </summary>
        /// <returns></returns>
        public static string Now()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        /// <summary>
        /// 当前时间yyyyMMddHHmmssfff
        /// </summary>
        /// <returns></returns>
        public static string Timespan()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }





        /// <summary>
        /// 操作系统0 ：windows ； 1： linux
        /// </summary>
        static string oSspliter;
        /// <summary>
        /// 操作系统0 ：windows ； 1： linux
        /// </summary>
        public static string OSspliter
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(getCFG(Environment.CurrentDirectory + @"\AppConfig.xml", "OS")) == 0)
                    {
                        return @"\";
                    }
                    else
                    {
                        return @"/";
                    }
                }
                catch (System.Exception ex)
                {
                    return @"/";
                }

            }
            set { oSspliter = value; }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="cfg">需要获取配置</param>
        /// <returns>配置参数</returns>
        public static string getCFG(string path, string cfg)
        {
            string cfgstr = "";
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode Root = doc.SelectSingleNode("AppSettings");
                foreach (XmlNode child in Root)
                {
                    if (child.Name == cfg)
                    {
                        if (child.InnerText != "")
                        {
                            cfgstr = child.InnerText;
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {
                cfgstr = "";
            }
            return cfgstr;

        }



        #region 获取配置 "cfg"需要获取节点
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg">配置名</param>
        /// <param name="mark">0解密密文(可选)</param>
        /// <param name="initText">初始创建文件内节点配置(第一次使用时必须配置)</param>
        /// <param name="init">是否初始化删除</param>
        /// <param name="xmlPath">配置文件路径(可选)</param>
        /// <returns></returns>
        public static string getCFG(string cfg, string mark, string initText ,string init, string xmlPath = @"C:\Mssunsoft\PayApi\appconfig.xml")
        {
            string cfgstr = "";
            try
            {
                if (init.Equals("1"))
                {
                    File.Delete(xmlPath);
                }
                if (!File.Exists(xmlPath))
                {
                    //throw new Exception("路径:" + @"C:\Mssunsoft\PayApi\" + "不存在appconfig.xml文件");
                    try
                    {
                        //string re = @"<?xml version='1.0' encoding='utf-8'?><AppSettings><SQL>Server =.;DataBase = HXDLPIC;User Id = sa;Password =1989789mjw;Trusted_Connection = False;</SQL></AppSettings>";
                        #region 初次使用创建配置文件
                        StringBuilder re = new StringBuilder();
                        re.Append(@"<?xml version='1.0' encoding='utf-8'?><AppSettings>");
                        re.Append(initText);
                        //re.Append(@" <!-- 数据库地址 非his加密-->");
                        //re.Append(@" <SQL>889B3FC4CEE677525CD113D52AD8CB5C11AA3D224389C203ED303775CD379F5CE77590417B4092794D6AB733A82348BF53BBF1E984DCCE01F7899715BF5092895089481A110F8DA41FB617E1ED9F68E06F55000012C1764A9F5A83A77A81CCFA075A09A6CE43E76CB4BF42879CC5F9A2</SQL>");
                        //re.Append(@" <!-- 医疗区域 -->");
                        //re.Append(@" <region>1F450F745B3CBB6427724831252E4C31</region>");
                        //re.Append(@" <!-- 贫困登记弹窗 -->");
                        //re.Append(@" <PoorTip>90CE032C44EA1BD9</PoorTip>");
                        //re.Append(@"<!-- 统筹区号 -->");
                        //re.Append(@" <areaCode>B74D7AE0D89B1CC7</areaCode>");
                        re.Append(@"</AppSettings>");
                        XmlDocument docCreate = new XmlDocument();
                        docCreate.LoadXml(re.ToString());
                        docCreate.Save(xmlPath);
                        #endregion


                    }
                    catch (Exception ex)
                    {
                        if (!File.Exists(xmlPath))
                        {
                            throw new Exception("不存在路径:" + xmlPath);

                        }
                        throw new Exception(ex.ToString());
                    }

                }
                XmlDocument doc = new XmlDocument();
                // doc.Load(Environment.CurrentDirectory + @"\appconfig.xml");
                doc.Load(xmlPath);

                XmlNode Root = doc.SelectSingleNode("AppSettings");
                foreach (XmlNode child in Root)
                {
                    if (child.Name == cfg)
                    {
                        if (child.InnerText != "")
                        {
                            cfgstr = child.InnerText;
                        }
                        if (cfg.Equals("SQL") && string.IsNullOrEmpty(child.InnerText))
                        {
                            throw new Exception("未配置SQL连接字符串");
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            if (mark.Equals("0"))
            {
                return Encryption.Decrypt(cfgstr);
            }
            return cfgstr;

        }
        #endregion


        #region 获取本机ipv4
        /// <summary>
        /// 获取本机ipv4
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion


        #region 记录日志
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logName">日志文件名</param>
        /// <param name="log">日志内容</param>
        /// <param name="logTime">日志时间</param>
        public static void WriteLog(string logName, string log, string logTime)
        {
            try
            {
                string des = Environment.CurrentDirectory + "\\Log";
                if (!Directory.Exists(des))
                {
                    Directory.CreateDirectory(des);
                }
                string filename = des + "\\" + logName + " " + logTime.Split(' ')[0] + ".txt";
                FileStream myFileStream = new FileStream(filename, FileMode.Append);
                StreamWriter sw = new StreamWriter(myFileStream, System.Text.Encoding.Default);
                sw.WriteLine(log + "  " + logTime);
                myFileStream.Flush();
                sw.Close();
                myFileStream.Close();

            }
            catch (System.Exception ex)
            {

            }
        }
        #endregion

        #region 0x
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string hex2str(string hex)
        {

            StringBuilder sb = new StringBuilder(hex);
            sb.Replace("0x", "");
            return sb.ToString();

        }
        #endregion

        #region 该方法用于生成指定位数的随机字符串
        /// <summary>
        /// 该方法用于生成指定位数的随机字符串
        /// </summary>
        /// <param name="VcodeNum">参数是随机数的位数</param>
        /// <returns>返回一个随机数字符串</returns>
        public static string RndNumStr(int VcodeNum)
        {
            string[] source = { "0", "1", "1", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string checkCode = String.Empty;
            Random random = new Random();
            for (int i = 0; i < VcodeNum; i++)
            {
                checkCode += source[random.Next(0, source.Length)];

            }
            return checkCode;
        }
        #endregion



        #region 查找字符在字符串中第N次出现的位置

        /// <summary>
        /// 查找字符在字符串中第N次出现的位置
        /// 
        /// 异常;sequence参数越界
        /// </summary>
        /// <param name="inputString">字符串</param>
        /// <param name="charcterMark">需要查找的字符</param>
        /// <param name="sequence">出现的次数</param>
        /// <returns>出现的次数在字符串中的序列数</returns>
        public static int IndexNatureNumAppera(string inputString, string charcterMark, int sequence)
        {
            char c, find_c;

            if (Char.TryParse(charcterMark, out find_c))
            {
                int count = 0;
                for (int i = 0; i < inputString.Length; i++)
                {
                    c = inputString[i];
                    if (c == find_c)
                    {
                        count++;
                    }
                }
                int index = 0;
                if (sequence > count)
                {
                    throw new Exception("Error:The Num must be less than or equal to " + count);
                }

                for (int j = 1; j <= count; j++)
                {
                    index = inputString.IndexOf(find_c, index);
                    if (j == sequence)
                    { break; }
                    else
                    { index = inputString.IndexOf(find_c, index + 1); }
                }
                return index;
            }
            else
            {
                throw new Exception("输入的查找字符转换成Char类型出错!");
            }

            return 0;
        }

        #endregion

    }
    #endregion
}
