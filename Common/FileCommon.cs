using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Malkavian
{

    /// <summary>
    /// 文件帮助类
    /// </summary>
   public  class FileCommon
    {
       /// <summary>
       /// 文件列表结果
       /// </summary>
       static List<FileInfo> result;









       /// <summary>
       /// 遍历文件夹下的文件
       /// </summary>
       /// <param name="p">文件夹路径</param>
       private void ScanPic(string p)
       {
           result = new List<FileInfo>();
           List<FileInfo> allfiles = new List<FileInfo>();//全部文件列表
           DirectoryInfo dirinfo = new DirectoryInfo(p);//文件目录
           //DirectoryInfo[] directories = dirinfo.GetDirectories("*轮巡视",SearchOption.TopDirectoryOnly);
           //for (int i = 0; i < directories.Length; i++)
           //{
           //    allfiles = GetFiles(directories[i]);
           //    allfiles.AddRange(allfiles);
           //}
           allfiles = GetFiles(dirinfo);
          // WriteResult(@"f:\业务流\kvDown.txt", allfiles);
           //foreach (FileInfo item in allfiles)
           //{
           //    string fileName = item.Name;
           //    WriteResult(p,fileName);
           //}
       }






        /// <summary>
        /// 目录及子目录下的文件列表
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static List<FileInfo> GetFiles(DirectoryInfo directory)
        {

            if (directory.Exists)//目录存在
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles())//遍历取当前文件列表
                    {
                        result.Add(info);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                foreach (DirectoryInfo info in directory.GetDirectories())//遍历取当前目录的子目录
                {
                    GetFiles(info);//调用自身取子目录文件列表
                }
            }
            return result;
        }

    }
}
