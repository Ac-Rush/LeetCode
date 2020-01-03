using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.ArrayS
{
    class Two_Sum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new[] {i, dict[target - nums[i]]};
                }

                dict[nums[i]] = i;
            }

            return new[] {-1, -1};
        }
    }
}
