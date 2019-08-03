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
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                var m = l + (r - l) / 2;
                if (nums[m] == target) return m;
                if (nums[m] > target) r = m - 1;
                else l = m + 1;
            }
            return -1;
        }
    }
}
