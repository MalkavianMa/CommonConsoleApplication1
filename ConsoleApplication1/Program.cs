using System;
using System.Collections.Generic;
using System.Text;
using Malkavian;
using System.Data;
using Common4;
using FileCommonsFx4;

namespace ConsoleApplication1
{
    class Program
    {
        //string a = Common.getCFG("SQL");
        static void Main(string[] args)
        {
            //   Builder b = new Builder();
            //  // Console.WriteLine(b.a);
            //   string bh = b.a;
            //   Console.WriteLine(bh);
            //   Console.WriteLine(b.b);
            //   Console.WriteLine(b.c);
            //   Console.WriteLine(b.d);
            ////   if (!b.d.Equals("371329"))//371325
            //   {
            //       Console.WriteLine("异县结算,抛出异常");
            //   }
            // // Console.WriteLine(Encryption.Decrypt(bh, "MalkavianMa"));
            //  //LinkCommon lc = new LinkCommon();
            //  ExcelHelper exn = new ExcelHelper();
            // // Console.WriteLine(lc.getShotLink(@"http://www.baidu.com"));
            //  DataTable dt = new DataTable("test");
            //  //1.创建空列
            // // DataColumn dc = new DataColumn();
            //  //2.创建带列名和类型名的列(两种方式任选其一)
            // // dt.Columns.Add("column0", System.Type.GetType("System.String"));
            ////  dt.Columns.Add("column0", typeof(String));
            //  //3.通过列架构添加列
            //  DataColumn dc = new DataColumn("column1", System.Type.GetType("System.String"));
            //  DataColumn dc2 = new DataColumn("column2", typeof(DateTime));
            //  dt.Columns.Add(dc);
            //  dt.Columns.Add(dc2);

            //  //1.创建空行
            ////  DataRow dr = dt.NewRow();
            ////  dt.Rows.Add(dr);
            //  //2.创建空行
            ////  dt.Rows.Add();
            //  //3.通过行框架创建并赋值
            //  dt.Rows.Add("张三", DateTime.Now);//Add里面参数的数据顺序要和dt中的列的顺序对应 
            //  //4.通过复制dt2表的某一行来创建
            // // dt.Rows.Add(dt2.Rows[i].ItemArray);
            // // ExcelHelper.TableToExcel(dt, @"D:\2019年1月3日131731.xls");
            //  DataTable dt2 = new DataTable();
            //  dt2 = ExcelHelper.ExcelToTable(@"D:\2019年1月3日131731.xls");
            //  ////新建行的赋值
            //  //DataRow dr = dt.NewRow();
            //  //dr[0] = "张三";//通过索引赋值
            //  //dr["column1"] = DateTime.Now; //通过名称赋值
            //  ////对表已有行进行赋值
            //  //dt.Rows[0][0] = "张三"; //通过索引赋值
            //  //dt.Rows[0]["column1"] = DateTime.Now;//通过名称赋值
            ////取值
            //string name = dt.Rows[0][0].ToString();
            //string time = dt.Rows[0]["column1"].ToString();


            //MalkavianFile mf = new MalkavianFile();
            //MalkavianFile.CopyDir(@"D:\AK\新建文件夹", @"C:\Mssunsoft\PayApi",false);
            MathCommon mathCommon = new MathCommon();
            decimal h = 0;
           MathCommon.ConvertResult("","你好");

            Console.ReadKey();
           
        }
    }
}
