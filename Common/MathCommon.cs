using System;
using System.Collections.Generic;
using System.Text;

namespace Malkavian
{
    /// <summary>
    /// 专用数学类
    /// </summary>
    public class MathCommon
    {

        public MathCommon()
        {

        }

        /// <summary>
        ///  转换为指定类型 有异常返回初始值  例如decimal 有异常返回0
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">值</param>
        /// <param name="result">转换的字符串</param>
        /// <returns></returns>
        public static T ConvertResult<T>(T t, string result) //where T : class

        {



            try
            {
                switch (t.GetType().ToString())
                {
                    case
                           "System.Decimal":
                        decimal initDecimal = 0;
                        if (decimal.TryParse(result, out initDecimal))
                        {
                            t = (T)Convert.ChangeType(initDecimal, typeof(T));

                        }
                        else
                        {
                            // Object d = (Object)t;
                            // initDecimal = Convert.ToDecimal(d);

                            //  Object e = (Object)initDecimal;
                            return (T)Convert.ChangeType(initDecimal, typeof(T));

                        }
                        break;
                    case "System.Int32":
                        int initInt32 = 0;
                        if (int.TryParse(result, out initInt32))
                        {
                            t = (T)Convert.ChangeType(initInt32, typeof(T));

                        }
                        else
                        {
                            // Object d = (Object)t;
                            // initDecimal = Convert.ToDecimal(d);

                            //  Object e = (Object)initDecimal;
                            return (T)Convert.ChangeType(initInt32, typeof(T));

                        }

                        break;

                    default:
                     
                            t= (T)Convert.ChangeType(result, typeof(T));

                      
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return t;
        }





    }
}
