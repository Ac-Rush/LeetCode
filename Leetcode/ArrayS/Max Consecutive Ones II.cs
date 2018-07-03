using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Max_Consecutive_Ones_II
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var count = 0;
            var max = 0;
            var prev = 0;
            bool has0 = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    max = Math.Max(count + prev + 1, max);
                    prev = count;
                    count = 0;
                    has0 = true;
                }
            }
            if (has0 )
            {
                count = count + prev + 1;
            }
            return Math.Max(count, max);
        }
    }
}
