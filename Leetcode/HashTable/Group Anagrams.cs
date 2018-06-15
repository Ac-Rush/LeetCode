using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Group_Anagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var charMap = new int[26];
                foreach (var c in str)
                {
                    charMap[c - 'a']++;
                }
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');   // my bug int[] 做key 没法用dict, 采用自编码的 string做key
                    sb.Append(charMap[i]);
                }
                var key = sb.ToString();
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new List<string>();
                }
               
                dict[key].Add(str);
            }
            var result = new List<IList<string>>();
            foreach (var value in dict.Values)
            {
                result.Add(value);

            }
            return result;
        }
    }
}
