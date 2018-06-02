using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Palindromic_Substrings
    {
        /// <summary>
        /// my solution
        /// 用dp 表记录 j~i是不是回文
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountSubstrings(string s)
        {
            var count = 0;
            var dp = new bool[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (i == j || (s[i] == s[j] && (j == i - 1 || dp[j + 1, i - 1])))
                    {
                        dp[j, i] = true;
                        count++;
                    }
                }
            }
            return count;
        }


        int count = 0;

        public int CountSubstrings2(String s)
        {
            if (s == null || s.Length == 0) return 0;

            for (int i = 0; i < s.Length; i++)
            { // i is the mid point
                extendPalindrome(s, i, i); // odd length;
                extendPalindrome(s, i, i + 1); // even length
            }

            return count;
        }

        private void extendPalindrome(String s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                count++; left--; right++;
            }
        }
    }
}
