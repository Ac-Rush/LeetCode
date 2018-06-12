using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Longest_Valid_Parentheses
    {
        public int LongestValidParentheses(string s)
        {
            var max = 0;
            var dp = new int[s.Length ];
            for (int i = 1; i < dp.Length; i++)
            {
                if (s[i ] == ')')
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    }
                    else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                    }
                    max = Math.Max(max, dp[i]);
                }
            }
            return max;
        }
    }
}
