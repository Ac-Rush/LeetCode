using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Binary_Search
    {
        public int Search(int[] nums, int target)
        {
            var l = 0;
            var h = nums.Length - 1;
            while (l <= h)
            {
                var m = l + (h - l) / 2;
                if (nums[m] == target) return m;
                if (nums[m] < target) l = m + 1;
                else h = m - 1;
            }
            return -1;
        }
    }
}
