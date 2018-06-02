using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Integer_Break
    {
        /// <summary>
        /// my math solution 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int IntegerBreak(int n)
        {
            if (n == 2)
            {
                return 1;
            }
            if (n == 3)
            {
                return 2;
            }

            var mod = n%3;
            if (mod == 0)
            {
                return (int)Math.Pow(3, n/3);
            }
            if (mod == 1)
            {
                return (int)Math.Pow(3, n / 3 -1) * 4;
            }
            return (int)Math.Pow(3, n / 3) * 2;
        }

        /// <summary>
        /// dp solution
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int integerBreak(int n)
        {
            int[] dp = new int[n + 1];
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    dp[i] = Math.Max(dp[i], (Math.Max(j, dp[j])) * (Math.Max(i - j, dp[i - j])));
                }
            }
            return dp[n];
        }
    }
}
