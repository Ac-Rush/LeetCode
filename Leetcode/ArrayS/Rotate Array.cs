using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Rotate_Array
    {
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] nums, int l, int r)
        {
            while (l < r)
            {
                var temp = nums[l];
                nums[l] = nums[r];
                nums[r] = temp;
                l++;  // my bug, missed again
                r--;
            }
        }
    }
}
