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
                if (hash[s[end]] == 0) // 不要太复杂， 如果末尾是个新元素
                {
                    hash[s[end++]]++;  // 更新 hash, end++, 
                    max = Math.Max(max, end - start);  // 更新长度
                }
                else
                {
                    hash[s[start++]] = 0;  // 否则就 处理start, 不用while 套 while 很是麻烦
                }
            }
            return max;
        }
    }
}
