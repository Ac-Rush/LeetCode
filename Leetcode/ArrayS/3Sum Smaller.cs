using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class _3Sum_Smaller_TwoPointer
    {
        public int ThreeSumSmaller(int[] nums, int target)
        {
            var count = 0;
            System.Array.Sort(nums);
            int len = nums.Length;

            for (int i = 0; i < len - 2; i++)
            {
                int left = i + 1, right = len - 1;
                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] < target)
                    {
                        count += right - left;
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return count;
        }
        
    }

    class _3Sum_Smaller_BinarySearch
    {
        public int ThreeSumSmaller(int[] nums, int target)
        {
            System.Array.Sort(nums);
            var count = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                count += twoSumSmaller(nums, i + 1, target - nums[i]);
            }
            return count;
        }
        private int twoSumSmaller(int[] nums, int startIndex, int target)
        {
            int sum = 0;
            for (int i = startIndex; i < nums.Length - 1; i++)
            {
                int j = binarySearch(nums, i, target - nums[i]);
                sum += j - i;
            }
            return sum;
        }

        private int binarySearch(int[] nums, int startIndex, int target)  //找最后一个比target 小的？
        {
            int left = startIndex;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right + 1) / 2;
                if (nums[mid] < target)  
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }
    }
}
