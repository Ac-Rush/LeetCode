using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class TimeMap
    {
        Dictionary<string, SortedList<int, string>> dict;

        /** Initialize your data structure here. */
        public TimeMap()
        {
            dict = new Dictionary<string, SortedList<int, string>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (dict.ContainsKey(key)) dict[key].Add(timestamp, value);
            else dict.Add(key, new SortedList<int, string>() { { timestamp, value } });
        }

        public string Get(string key, int timestamp)
        {
            if (dict.ContainsKey(key))
            {
                var list = dict[key]; 
                for (int i = timestamp; i > 0; i--)
                {
                    if (list.ContainsKey(i)) return list[i];
                }
            }
            return string.Empty;
        }
    }
}
