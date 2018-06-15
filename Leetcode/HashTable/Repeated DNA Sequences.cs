using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Repeated_DNA_Sequences
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < s.Length - 9; i++)
            {
                var key = s.Substring(i, 10);
                if (!dict.ContainsKey(key))
                {
                    dict[key] = 0;
                }
                dict[key]++;
            }
            var result = new List<string>();
            foreach (var key in dict.Keys)
            {
                if (dict[key] > 1)
                {
                    result.Add(key);
                }
            }
            return result;
        }
    }
}
