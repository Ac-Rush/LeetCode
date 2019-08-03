using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Max_Consecutive_Ones
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var count = 0;
            var max = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    max = Math.Max(count, max);
                    count = 0;
                }
            }
            return Math.Max(count, max);
        }
    }
}
