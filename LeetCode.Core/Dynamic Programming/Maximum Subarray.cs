using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-subarray/description/
    /// </summary>
    class Maximum_Subarray
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var max = nums[0];
            var globalMax = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                max = Math.Max(nums[i], nums[i] + max);
                if (max > globalMax) globalMax = max;
            }
            return globalMax;
        }


        public int MaxSubArray2(int[] nums)
        {
            int max = int.MinValue, cur = 0;
            foreach (var n in nums)
            {
                cur = Math.Max(n, cur + n);
                max = Math.Max(max, cur);
            }
            return max;
        }
    }
}
