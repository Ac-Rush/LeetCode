using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.TwoPointer
{
    class Array_Partition_I
    {
        public int ArrayPairSum(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }
            System.Array.Sort(nums);
            var sum = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }
            return sum;

        }
    }
}
