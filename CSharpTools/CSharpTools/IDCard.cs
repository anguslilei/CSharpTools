using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools
{
    public class IDCard
    {
        public IDCard(string id, string name = "")
        {
            if (id.Length != 18)
                throw new Exception("身份证号码长度不正确，请检查！");

        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string ID { get; private set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Region { get; private set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; private set; }
    }
}
