using System;
using System.Collections;
using System.Linq;

namespace CSharpTools
{
    /// <summary>
    /// 拓展方法
    /// </summary>
    public static class Extentions
    {
        /// <summary>
        /// 将字符串数组转字符串输出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public static string ToStr(this string[] strArr)
        {
            return string.Join(",", strArr);
        }
        /// <summary>
        /// 将类公共属性打印成字符串输出
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="param">类实例</param>
        /// <returns></returns>
        public static string ToStr<T>(this T param) where T : class
        {
            try
            {
                var type = param.GetType();
                if (type.IsValueType || type.Name == "String")//值类型或者字符串类型
                {
                    return param.ToString();
                }
                if (type.IsArray)//若是数组
                {
                    var r = "[";

                    if (param is IList v)
                        foreach (var item in v)
                        {
                            r += item.ToStr();
                            r += ",";
                        }

                    r = r.TrimEnd(',');
                    r += "]";
                    return r;
                }

                var temp = param.GetType().GetProperties().Select(a => a.GetValue(param, null) == null ? "null" : a.GetValue(param, null).ToStr());
                return string.Join(",", temp);
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }
        /// <summary>
        /// 将类公共属性打印成字符串输出,格式Name=Value
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="param">类实例</param>
        /// <returns></returns>
        public static string ToLStr<T>(this T param) where T : class
        {
            try
            {


                var type = param.GetType();
                if (type.IsValueType || type.Name == "String")//值类型或者字符串类型
                {
                    return param.ToString();
                }
                if (type.IsArray)//若是数组
                {
                    var r = "[";

                    if (param is IList v)
                        foreach (var item in v)
                        {
                            r += item.ToStr();
                            r += ",";
                        }

                    r = r.TrimEnd(',');
                    r += "]";
                    return r;
                }

                var temp = param.GetType().GetProperties().Select(a => a.Name + "=" + (a.GetValue(param, null) == null ? "null" : a.GetValue(param, null).ToStr()));
                return string.Join(",", temp);
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }
    }
}
