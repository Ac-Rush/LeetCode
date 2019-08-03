using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Increasing_Triplet_Subsequence
    {
        /// <summary>
        /// my solution  一次过
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IncreasingTriplet(int[] nums)
        {
            if (nums == null || nums.Length < 3) return false;
            var leftMin = new int[nums.Length];
            var rightMax = new int[nums.Length];
            leftMin[0] = nums[0];
            rightMax[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = 1; i < nums.Length; i++)
            {
                leftMin[i] = Math.Min(leftMin[i - 1], nums[i]);
            }

            for (int i = nums.Length -2; i >=0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], nums[i]);
            }

            for (int i = 1; i < nums.Length -1; i++)
            {
                if (nums[i] > leftMin[i - 1] && nums[i] < rightMax[i + 1])
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 其实就是找 第一小， 第二小， 然后找到一个大的
        /// 贪心算法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IncreasingTriplet2(int[] nums)
        {
            // start with two largest values, as soon as we find a number bigger than both, while both have been updated, return true.
            int small = int.MaxValue, big = int.MaxValue;
            foreach (int n in nums)
            {
                if (n <= small) { small = n; } // update small if n is smaller than both
                else if (n <= big) { big = n; } // update big only if greater than small but smaller than big
                else return true; // return if you find a number bigger than both
            }
            return false;
        }
    }
}
