﻿namespace Leetcode.ArrayS
{
    class _3Sum_Closest
    {
        /// <summary>
        ///  先排序 选定一个数， 然后 i+1, length-1 之间 twopointer 并保存更新 minDiff
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            var result = 0;
            System.Array.Sort(nums);
            int min = int.MaxValue;


            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int diff = System.Math.Abs(sum - target);

                    if (diff == 0) return sum;

                    if (diff < min)
                    {
                        min = diff; // update min
                        result = sum;  // update result
                    }
                    if (sum <= target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return result;
        }
    }
}
