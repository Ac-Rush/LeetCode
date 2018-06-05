using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Longest_Palindromic_Subsequence
    {
        public int LongestPalindromeSubseq(string s)
        {
            return LCS(s, Reverse(s));
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            System.Array.Reverse(charArray);
            return new string(charArray);
        }

        public int LCS(string s, string t)
        {
            var dp = new int[s.Length + 1, t.Length + 1];
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    if (s[i - 1] == t[j = 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[s.Length, t.Length];
        }
    }
}
