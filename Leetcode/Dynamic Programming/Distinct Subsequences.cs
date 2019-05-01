using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Distinct_Subsequences
    {
        /*
         * 二维动态规划 + 滚动数组
         *  如果不相等 dp[j + 1] = dp[j]
         *   如果相等 dp[j + 1]+=  dp[j]
         */
        public int NumDistinct(string S, string T)
        {
            var dp = new int[T.Length + 1];
            dp[0] = 1;
            for (int i = 0; i < S.Length; ++i)
            {
                for (int j = T.Length - 1; j >= 0; --j)
                {
                    dp[j + 1] += S[i] == T[j] ? dp[j] : 0;
                }
            }
            return dp[T.Length];
        }
    }
}
