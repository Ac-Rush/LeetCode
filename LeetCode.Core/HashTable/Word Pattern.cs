using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Word_Pattern
    {
        public bool WordPattern(string pattern, string str)
        {
            String[] words = str.Split(' ');
            if (words.Length != pattern.Length)
                return false;
            var map = new Dictionary<char, string>();
            for (int i = 0; i < words.Length; i++)
            {
                char c = pattern[i];
                if (map.ContainsKey(c))
                {
                    if (!map[c].Equals(words[i]))
                        return false;
                }
                else
                {
                    if (map.ContainsValue(words[i]))
                        return false;
                    map[c] = words[i];
                }
            }
            return true;
        }
    }
}
