using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Sort_Characters_By_Frequency
    {
        public string FrequencySort(string s)
        {
            var dict = new Dictionary<char,int>();
            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                {
                    dict[c] = 0;
                }
                dict[c]++;
            }

            var result = string.Empty;
            foreach (var key in dict.Keys.OrderByDescending( key => dict[key]))
            {
                    result += new string(key, dict[key]); 
            }
            return result;
        }
    }
}
