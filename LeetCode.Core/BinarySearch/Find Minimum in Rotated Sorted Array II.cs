using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Find_Minimum_in_Rotated_Sorted_Array_II
    {
        /// <summary>
        /// so esay, 一次性解决
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            var l = 0;
            var h = nums.Length - 1;
            while (l < h)
            {
                var mid = l + (h - l)/2;
                if (nums[mid] > nums[h])
                {
                    l = mid + 1;
                }
                else if (nums[mid] < nums[h])
                {
                    h = mid;
                }
                else
                {
                    h--; // 这个是必须的， 否则死循环
                }
            }
            return nums[l];
        }
    }
}
