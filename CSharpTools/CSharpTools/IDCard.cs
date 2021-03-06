﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools
{
    /// <summary>
    /// 身份证
    /// </summary>
    public class IDCard
    {
        private readonly List<int> _intArr=new List<int>();
        private readonly List<char> _charArr;
        private readonly List<int> _arr = new List<int>(){ 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        private readonly List<char> _map = new List<char>() { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
        public IDCard(string id, string name = "")
        {
            id = id.ToUpper();//大写
            ID = id;
            Name = name;
            if (id != ""&& id.Length == 18)
            {
                _charArr = id.ToList();//将字符串变为字符数组
                for (var i = 0; i < 17; i++)//保存前17位数字
                {
                    var t = _charArr[i] - '0';        
                    if (t > 9)
                        throw new Exception("身份证号" + id + "有误，请检查");
                    _intArr.Add(t);
                }

                if (!Valid(id))
                    throw new Exception("身份证" + id + "校验失败，请检查！");
                Sex = (Sex)(_intArr[16] % 2);
                Region = (Region)(_intArr[0]);
                Province = (Province)(_intArr[0] * 10 + _intArr[1]);
                City = (City)(int.Parse(id.Substring(0, 4)));
                District = (District)(int.Parse(id.Substring(0, 6)));
                Birthday = DateTime.ParseExact(id.Substring(6, 8), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            }
        }
        /// <summary>
        /// 第18位校验
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Valid(string id)
        {
            var sum = 0;
            for(var i = 0; i < 17; i++)
            {
                sum += _intArr[i] * _arr[i];
            }
            return _charArr[17] == _map[sum % 11];
            
        }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string ID { get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 区域
        /// </summary>
        public Region Region { get; private set; }
        /// <summary>
        /// 省份
        /// </summary>
        public Province Province { get; private set; }
        /// <summary>
        /// 城市
        /// </summary>
        public City City { get; private set; }
        /// <summary>
        /// 区县
        /// </summary>
        public District District { get; private set;}
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
