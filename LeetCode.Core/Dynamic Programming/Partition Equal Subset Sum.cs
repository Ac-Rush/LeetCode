using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Partition_Equal_Subset_Sum
    {
        public bool canPartition1(int[] nums)
        {
            var sum = nums.Sum();
            if (sum % 2 != 0)
            {
                return false;
            }
            sum /= 2;

            int n = nums.Length;
            var dp = new bool[n + 1,sum + 1];

            dp[0,0] = true;


            for (int i = 1; i < n + 1; i++)
            {
                dp[i,0] = true;
            }
            for (int j = 1; j < sum + 1; j++)
            {
                dp[0,j] = false;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < sum + 1; j++)
                {
                    dp[i,j] = dp[i - 1,j];
                    if (j >= nums[i - 1])
                    {
                        dp[i,j] = (dp[i,j] || dp[i - 1,j - nums[i - 1]]);
                    }
                }
            }

            return dp[n,sum];
        }

        /// <summary>
        /// 一维解法是由上面推导出来的， 想不出来
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            var sum = nums.Sum();
            if (sum % 2 != 0)
            {
                return false;
            }
            sum /= 2;

            int n = nums.Length;
            bool[] dp = new bool[sum + 1];
            
            dp[0] = true;

            foreach (var num in nums)
            {
                for (int i = sum; i > 0; i--)
                {
                    if (i >= num)
                    {
                        dp[i] = dp[i] || dp[i - num];
                    }
                }
            }

            return dp[sum];
        }

      
    }
}
