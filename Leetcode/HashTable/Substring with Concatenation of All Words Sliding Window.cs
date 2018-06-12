using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Substring_with_Concatenation_of_All_Words_Sliding_Window
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            var map = new char[256];
            int count = 0;
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    map[c]++;
                    count++;
                }
            }
            int start = 0, end = 0, length = count;

            while (end < s.Length)
            {
                if (map[s[end++]]-- > 0) count--;
                if (count == 0 && end - start == length)
                {
                    result.Add(start);
                }
                if (end - start >= length && map[s[start++]]++ >= 0) count++;
            }

            return result;
        }
    }
}
