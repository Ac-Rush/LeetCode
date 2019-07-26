using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class SearchInsertC
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (nums[0] >= target)
            {
                return 0;
            }
            if (nums[nums.Length - 1] < target)
            {
                return nums.Length;
            }

            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                var mid = start + (end - start) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid; // 右边等于 mid不会死循环
                }
            }
            return start;
        }
    }
}
