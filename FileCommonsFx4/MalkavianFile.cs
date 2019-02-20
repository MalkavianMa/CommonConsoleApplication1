using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Malkavian;
using Microsoft.VisualBasic.Devices;
namespace FileCommonsFx4
{
   public class MalkavianFile
    {
       public static void CopyDir(string fromDir, string toDir,bool  deleteSource)
       {
           if (!Directory.Exists(fromDir))
               return;

           if (!Directory.Exists(toDir))
           {
               Directory.CreateDirectory(toDir);
           }

           string[] files = Directory.GetFiles(fromDir);
           foreach (string formFileName in files)
           {
               string fileName = Path.GetFileName(formFileName);
               string toFileName = Path.Combine(toDir, fileName);
               try
               {
                 //  Common.WriteLog("隔离程序", "移动 " + formFileName + "  到  " + toFileName + Common.OSspliter + fileName + "。", Common.Now());

                   if (Directory.Exists(@"C:\Mssunsoft\PayApi"))
                   {
                       //using Microsoft.VisualBasic.Devices;

                      // Computer MyComputer = new Computer();
                     //  MyComputer.FileSystem.RenameDirectory(@"C:\Mssunsoft\PayApi", "PayApi" + Common.Timespan());
                       
                   }
                   try
                   {
                       //if (!Directory.Exists(fromDir))
                       //    return;

                       //if (!Directory.Exists(toDir))
                       //{
                       //    Directory.CreateDirectory(toDir);
                       //}
                       if (File.Exists(toFileName))
                       {//
                          // string[] k = toFileName.Split('\\');
                          // string kb = k[k.Length - 1].ToString();
                           string str = toFileName;
                           char[] delimiterChars = { '.', '\\' };
                           string[] Mystr = str.Split(delimiterChars);
                           string sheetName = Mystr[Mystr.Length - 2];// 没有扩展名的文件名 “Defaul
                 //File.Delete(toFileName);
               //  File.Replace(formFileName, toFileName, sheetName + Common.Timespan());
                           Computer MyComputer = new Computer();
                           MyComputer.FileSystem.RenameFile(toFileName, sheetName+Common.Timespan()+Path.GetExtension(str));
                           File.Copy(formFileName, toFileName);

                       }
                       else
                       {
                           File.Copy(formFileName, toFileName);
                       }
                   }
                   catch (System.Exception ex)
                   {
                       
                   }

                   if (deleteSource)
                   {
                       try
                       {
                           File.Delete(formFileName);
                       }
                       catch (System.Exception ex)
                       {

                       } 
                   }
               }
               catch (System.Exception ex)
               {
                   Common.WriteLog("DataSync_R", "复制文件" + formFileName + "到" + toFileName + "时出错：" + ex.Message.ToString(), Common.Now());
               }
           }
           string[] fromDirs = Directory.GetDirectories(fromDir);
           foreach (string fromDirName in fromDirs)
           {
               string dirName = Path.GetFileName(fromDirName);
               string toDirName = Path.Combine(toDir, dirName);
               CopyDir(fromDirName, toDirName,false);
           }
       }
    }
}
