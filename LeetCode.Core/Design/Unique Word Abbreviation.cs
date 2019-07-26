using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class ValidWordAbbr
    {
        Dictionary<String, String> map;
        public ValidWordAbbr(string[] dictionary)
        {
            map= new Dictionary<string, string>();  //<key , str>
            foreach (var str in dictionary)
            {
                String key = getKey(str);
                // If there is more than one string belong to the same key
                // then the key will be invalid, we set the value to ""
                if (map.ContainsKey(key))
                {
                    if (!map[key].Equals(str))
                    {
                        map[key] =  "";
                    }
                }
                else
                {
                    map[key] =  str;
                }
            }
        }

        public bool IsUnique(string word)
        {
            return !map.ContainsKey(getKey(word)) || map[getKey(word)].Equals(word);
        }
        String getKey(String str)
        {
            if (str.Length <= 2) return str;
            return str[0] + (str.Length - 2).ToString() + str[str.Length - 1];
        }
    }
}
