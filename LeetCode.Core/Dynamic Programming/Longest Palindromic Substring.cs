using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Longest_Palindromic_Substring_2
    {
        /// <summary>
        /// Approach 4: Expand Around Center
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2; //巧妙地计算 了 start 和 end
                    end = start + len - 1;
                }
            }
            return s.Substring(start, end + 1 - start );
        }

        private int expandAroundCenter(String s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }
    }

    /// <summary>
    ///  time O N^2 空间 O N^2
    /// </summary>
    class Longest_Palindromic_Substring_DP
    {
        public string LongestPalindrome(string s)
        {
            int n = s.Length;

            int longestBegin = 0;

            int maxLen = 1;

            var table = new bool[n, n];

            for (int i = 0; i < n; i++)
            {

                table[i, i] = true; //前期的初始化   长度为1 的肯定是回文

            }

            for (int i = 0; i < n - 1; i++)
            {

                if (s[i] == s[i + 1])  //如果相邻的两个相同， 长度为2 的也是回文
                {

                    table[i, i + 1] = true; //前期的初始化  

                    longestBegin = i;

                    maxLen = 2;

                }

            }

            for (int len = 3; len <= n; len++)  // 长度为3 以上的 就可以套用  F(3) = f(1) 如果f(1)左右相同
            {

                for (int i = 0; i < n - len + 1; i++)
                {

                    int j = i + len - 1;

                    if (s[i] == s[j] && table[i + 1, j - 1])
                    {

                        table[i, j] = true;

                        longestBegin = i;

                        maxLen = len;

                    }

                }

            }

            return s.Substring(longestBegin, maxLen);
        }
    }
}
