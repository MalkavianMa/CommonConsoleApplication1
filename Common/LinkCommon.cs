using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Malkavian
{

    /// <summary>
    /// 短链接
    /// </summary>
    public class LinkCommon
    {

        /// <summary>
        /// 获取短链接
        /// </summary>
        /// <param name="tUrl"></param>
        /// <returns></returns>
        public string getShotLink(string tUrl)
        {
            string url = "http://api.t.sina.com.cn/short_url/shorten.xml?source=3271760578&url_long=";
            url = url + HttpUtility.UrlEncode(tUrl, System.Text.Encoding.GetEncoding(65001));
            url = AssGetCFG.getCFG(GetshotUrl(url));
            return url;
        }


        private string GetshotUrl(string uri)
        {
            string content = "";
            //请求  
            // string uri = " http://www.baidu.com";
            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";                            //请求方法  
            request.ProtocolVersion = new Version(1, 1);   //Http/1.1版本  
            //Add Other ...  
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Header  
            //foreach (var item in response.Headers)
            //{
            //   // this.txt_Header.Text += item.ToString() + ": " +
            //  //   response.GetResponseHeader(item.ToString())
            //   //  + System.Environment.NewLine;
            //}

            //如果主体信息不为空，则接收主体信息内容  
            if (response.ContentLength <= 0)
                return "response null";
            //接收响应主体信息  
            using (Stream stream = response.GetResponseStream())
            {
                //byte[] bytes = new byte[stream.Length];
                //stream.Read(bytes, 0, bytes.Length);
                //stream. Seek(0, SeekOrigin.Begin);
                int totalLength = (int)response.ContentLength;
                int numBytesRead = 0;
                byte[] bytes = new byte[totalLength + 1024];
                //通过一个循环读取流中的数据，读取完毕，跳出循环  
                while (numBytesRead < totalLength)
                {
                    int num = stream.Read(bytes, numBytesRead, 1024);  //每次希望读取1024字节  
                    if (num == 0)   //说明流中数据读取完毕  
                        break;
                    numBytesRead += num;
                }
                content = Encoding.UTF8.GetString(bytes);
                //将接收到的主体数据显示到界面  
                //this.txt_Content.Text = content;
            }

            return content;
        }
    }
}
