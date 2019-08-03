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
            var dp = new int[s.Length,s.Length];

            for (int i = s.Length - 1; i >= 0; i--)
            {
                dp[i,i] = 1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        dp[i,j] = dp[i + 1,j - 1] + 2;
                    }
                    else
                    {
                        dp[i,j] = Math.Max(dp[i + 1,j], dp[i,j - 1]);
                    }
                }
            }
            return dp[0,s.Length - 1];
        }


        public int LongestPalindromeSubseq2(string s)
        {
            var dp = new int[s.Length, s.Length];

            for (int i = 0 ; i <s.Length; i++)
            {
                dp[i, i] = 1;
                for (int j = i-1; j >=0; j--)
                {
                    if (s[i] == s[j])
                    {
                        dp[j,i] = dp[j+1, i -1] + 2;
                    }
                    else
                    {
                        dp[j, i] = Math.Max(dp[j +1 ,i], dp[j, i-1]);
                    }
                }
            }
            return dp[0, s.Length - 1];
        }
        /// <summary>
        /// Top bottom recursive method with memoization
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int longestPalindromeSubseq3(String s)
        {
            return helper(s, 0, s.Length - 1, new int?[s.Length, s.Length]);
        }

        private int helper(String s, int i, int j, int?[,] memo)
        {
            if (memo[i,j] != null)
            {
                return memo[i,j].Value;
            }
            if (i > j) return 0;
            if (i == j) return 1;

            if (s[i] == s[j])
            {
                memo[i,j] = helper(s, i + 1, j - 1, memo) + 2;
            }
            else
            {
                memo[i,j] = Math.Max(helper(s, i + 1, j, memo), helper(s, i, j - 1, memo));
            }
            return memo[i,j].Value;
        }
    }
}
