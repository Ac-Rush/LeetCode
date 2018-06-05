using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Target_Sum
    {
        /// <summary>
        /// 2D DP
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int S)
        {
            if (S >= 1000)
            {
                return 0;
            }
            var n = nums.Length;
            var dp = new int[n, 2000];
            dp[0,nums[0] + 1000] = 1;
            dp[0,-nums[0] + 1000] += 1;
            for (int i = 1; i < n; i++)
            {
                for (int sum = -1000; sum <= 1000; sum++)
                {
                    if (dp[i - 1,sum + 1000] > 0)
                    {
                        dp[i,sum + nums[i] + 1000] += dp[i - 1,sum + 1000];
                        dp[i,sum - nums[i] + 1000] += dp[i - 1,sum + 1000];
                    }
                }
            }


            return S > 1000 ? 0 : dp[n - 1,S + 1000];
        }

        /// <summary>
        /// 1D DP  
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays2(int[] nums, int S)
        {
            var n = nums.Length;
            var dp = new int[ 2001];
            dp[nums[0] + 1000] = 1;
            dp[-nums[0] + 1000] += 1;
            for (int i = 1; i < n; i++)
            {
                int[] next = new int[2001];   //复制 next数组 来实现变成2行的 DP
                for (int sum = -1000; sum <= 1000; sum++)
                {
                    if (dp[ sum + 1000] > 0)
                    {
                        next[ sum + nums[i] + 1000] += dp[sum + 1000];
                        next[sum - nums[i] + 1000] += dp[sum + 1000];
                    }
                }
                dp = next;
            }


            return S > 1000 ? 0 : dp[S + 1000];
        }
    }
}
