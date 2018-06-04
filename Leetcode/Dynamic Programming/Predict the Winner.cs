using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Predict_the_Winner
    {
        /// <summary>
        /// Approach #1 Using Recursion [Accepted]
        /// O(2^N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool PredictTheWinner(int[] nums)
        {
            return Winner(nums, 0, nums.Length - 1, 1) >= 0;
        }
        public int Winner(int[] nums, int s, int e, int turn)
        {
            if (s == e)
                return turn * nums[s];
            int a = turn * nums[s] + Winner(nums, s + 1, e, -turn);
            int b = turn * nums[e] + Winner(nums, s, e - 1, -turn);
            return turn * Math.Max(turn * a, turn * b);
        }



        /// <summary>
        /// O(N^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool PredictTheWinner2(int[] nums)
        {
            var memo = new int?[nums.Length,nums.Length];
            return winner(nums, 0, nums.Length - 1, memo) >= 0;
        }
        public int winner(int[] nums, int s, int e, int?[,] memo)
        {
            if (s == e)
                return nums[s];
            if (memo[s,e] != null)
                return memo[s, e].Value;
            int a = nums[s] - winner(nums, s + 1, e, memo);
            int b = nums[e] - winner(nums, s, e - 1, memo);
            memo[s,e] = Math.Max(a, b);
            return memo[s,e].Value;
        }


        /// <summary>
        /// Approach #3 Dynamic Programming [Accepted]:
        /// 倒着做
        /// dp[s, e] 从s...e 数组里，第一个拿比第二个拿 多的数值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool PredictTheWinner3(int[] nums)
        {
            var dp = new int[nums.Length,nums.Length];
            for (int s = nums.Length -1; s >= 0; s--)
            {
                for (int e = s + 1; e < nums.Length; e++)
                {
                    int a = nums[s] - dp[s + 1,e];
                    int b = nums[e] - dp[s,e - 1];
                    dp[s,e] = Math.Max(a, b);
                }
            }
            return dp[0,nums.Length - 1] >= 0;
        }

        /// <summary>
        /// Approach #4 1-D Dynamic Programming [Accepted]:
        /// dp[i,j]=nums[i]−dp[i+1][j],nums[j]−dp[i][j−1].
        /// Thus, for filling in any entry in dpdp array, only the entries in the next row(same column) and the previous column(same row) are needed.
        /// 
        /// 这个没法想，只能推理过来
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool PredictTheWinner4(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int s = nums.Length; s >= 0; s--)
            {
                for (int e = s + 1; e < nums.Length; e++)
                {
                    int a = nums[s] - dp[e];
                    int b = nums[e] - dp[e - 1];
                    dp[e] = Math.Max(a, b);
                }
            }
            return dp[nums.Length - 1] >= 0;
        }
    }
}
