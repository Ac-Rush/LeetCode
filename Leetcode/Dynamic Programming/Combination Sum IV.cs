using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Combination_Sum_IV
    {
        /// <summary>
        ///  这个不一样， 这个去用 dp来做了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public int CombinationSum4(int[] nums, int target)
        {
            if (target == 0)
            {
                return 1;
            }
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (target >= nums[i])
                {
                    res += CombinationSum4(nums, target - nums[i]);
                }
            }
            return res;
        }


        private int[] dp;

        /// <summary>
        ///  top-down
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum42(int[] nums, int target)
        {
            dp = new int[target + 1];
            for (int index = 0; index < dp.Length; index++)
            {
                dp[index] = -1;
            }
            dp[0] = 1;
            return helper(nums, target);
        }

        private int helper(int[] nums, int target)
        {
            if (dp[target] != -1)
            {
                return dp[target];
            }
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (target >= nums[i])
                {
                    res += helper(nums, target - nums[i]);
                }
            }
            dp[target] = res;  //保存 每一层的res
            return res;
        }


        /// <summary>
        /// bottom-up
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int combinationSum43(int[] nums, int target)
        {
            int[] comb = new int[target + 1];
            comb[0] = 1;
            for (int i = 1; i < comb.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i - nums[j] >= 0)
                    {
                        comb[i] += comb[i - nums[j]];
                    }
                }
            }
            return comb[target];
        }
    }
}
