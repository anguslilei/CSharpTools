using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools
{
    public class IDCard
    {
        private List<int> intArr;
        private readonly List<char> charArr;
        private readonly List<int> arr = new List<int>(){ 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        private readonly List<char> map = new List<char>() { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
        public IDCard(string id, string name = "")
        {
            if (id.Length != 18)
                throw new Exception("身份证号码长度不正确，请检查！");
            if (!Valid(id))
                throw new Exception("身份证" + id + "校验失败，请检查！");
            charArr = id.ToList();
            for (int i = 0; i < 17; i++)
            {
                var t = charArr[i] - '0';
                if (t > 9)
                    throw new Exception("身份证号" + id + "有误，请检查");
                intArr.Add(t);
            }
            try
            {
                Sex = (Sex)(intArr[16] % 2);
                Region = (Region)(intArr[0]);
                Province = (Province)(intArr[0] * 10 + intArr[1]);
                Birthday = DateTime.ParseExact(id.Substring(6, 8), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        /// <summary>
        /// 第18位校验
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Valid(string id)
        {
            int sum = 0;
            for(int i = 0; i < 17; i++)
            {
                sum += intArr[i] * arr[i];
            }
            return charArr[17] == map[sum % 11];
            
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
        public Region Region { get; private set; }
        /// <summary>
        /// 省份
        /// </summary>
        public Province Province { get; private set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; private set; }
        /// <summary>
        /// 出生年月日
        /// </summary>
        public DateTime Birthday { get; private set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get { return DateTime.Now.Year - Birthday.Year + (DateTime.Now.Month - Birthday.Month) / 12; } }

    }
}
