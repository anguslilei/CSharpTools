using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpTools
{
    class Test
    {
        public static void Main()
        {
            IDCardTest();
           // RegexTest();
            
        }

        #region IDCardTest
        public static void IDCardTest()
        {
            IDCard iDCard = new IDCard("33012419920418351x", "嘿嘿嘿");
            Console.WriteLine(iDCard.ToLStr());
            Console.ReadKey();
        }
        #endregion

        #region RegexTest
        public static void RegexTest()
        {
            StreamReader sr = new StreamReader("201912251506.html");
            string content = sr.ReadToEnd();
           // string pattern = @"<td.*>(\d{4})00.+\n.*>(.*)</td>";
           string pattern= @"<td.*>(\d{5}[123456789]).+\n.*>(.*)</td>";
            var result = content.ExMatches(pattern);
            StreamWriter sw = new StreamWriter("2.txt");
            foreach(Match m in result)
            {
                var province= (Province)int.Parse(m.Groups[1].Value.Substring(0, 2));
                if (Enum.IsDefined(typeof(City), int.Parse(m.Groups[1].Value.Substring(0, 4))))
                {
                    Enum.TryParse<City>(m.Groups[1].Value.Substring(0, 4), out var city);

                    sw.WriteLine(city.ToString() + m.Groups[2].Value.ToString() + "=" + m.Groups[1].Value.ToString() + ",");

                }
                else
                    sw.WriteLine(province.ToString() + m.Groups[2].Value.ToString() + "=" + m.Groups[1].Value.ToString() + ",");


            }
            sr.Close();
            sw.Close();
            Console.ReadKey();

        }

        #endregion
    }
}
