using System;
using System.Collections.Generic;

namespace Leetcode.Array
{
    public class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new ArgumentException("No two sum solution");
        }
    }

    public class TwoSumSolution2
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    result[1] = i;
                    result[0] = map[target - nums[i]];
                    return result;
                }
                map[nums[i]]= i;   //这里一定要边查边放
            }
            return result;
            
        }
    }
}
