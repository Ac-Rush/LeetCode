using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Find_the_Difference
    {
        public char findTheDifference(String s, String t)
        {
            var set = new int[26];
            var set2 = new int[26];
            foreach (var c in s)
            {
                set[c-'a'] += 1;
            }
            foreach (var c in t)
            {
                set2[c - 'a'] += 1;
            }
            for (int i = 0; i < set.Length; i++)
            {
                if (set[i] != set2[i])
                {
                    return (char) ('a' + i);
                }
            }
            return ' ';
        }


        /// <summary>
        /// 异或， 找单个的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public char findTheDifference2(String s, String t)
        {
            int n = t.Length;
            char c = t[n - 1];
            for (int i = 0; i < n - 1; ++i)
            {
                c ^= s[i];
                c ^= t[i];
            }
            return c;
        }
    }
}
