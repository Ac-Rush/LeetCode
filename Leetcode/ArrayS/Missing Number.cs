using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Missing_Number
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            var sum = nums.Sum();
            return nums.Length*(nums.Length + 1)/2 - sum;
        }

        /// <summary>
        /// The basic idea is to use XOR operation. We all know that a^b^b =a, which means two xor operations with the same number will eliminate the number and reveal the original number.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber2(int[] nums)
        {
            int xor = 0, i = 0;
            for (i = 0; i < nums.Length; i++)
            {
                xor = xor ^ i ^ nums[i];
            }

            return xor ^ i;
        }
    }
}
