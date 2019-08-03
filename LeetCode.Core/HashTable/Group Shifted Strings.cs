using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Group_Shifted_Strings
    {
        /// <summary>
        /// 把第一个字母当做 offset， 把每个字母都减去offset，如果小于a要加26 ，去generate key
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var str in strings)
            {
                int offset = str[0] - 'a';
                String key = "";
                for (int i = 0; i < str.Length; i++)
                {
                    char c = (char)(str[i] - offset);
                    if (c < 'a')
                    {
                        c = (char)(c+ 26);
                    }
                    key += c;
                }
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new List<String>();
                }
                dict[key].Add(str);
            }
            return dict.Values.Cast<IList<string>>().ToList();
        }
    }
}
