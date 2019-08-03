using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Single_Number
    {
        public int SingleNumber(int[] nums)
        {
            var ret = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                ret ^= nums[i];
            }
            return ret;
        }
    }
}
