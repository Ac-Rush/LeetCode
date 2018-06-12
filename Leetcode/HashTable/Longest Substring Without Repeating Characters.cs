using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Longest_Substring_Without_Repeating_Characters
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0 ) return 0;
            int[] hash = new int[256]; //character hash
            

            int start = 0, end = 0,  max = 0;
            while (end < s.Length)
            {
                if (hash[s[end]] == 0)
                {
                    hash[s[end++]]++;
                    max = Math.Max(max, end - start);
                }
                else
                {
                    hash[s[start++]] = 0;
                }
            }
            return max;
        }
    }
}
