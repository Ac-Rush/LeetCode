using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    public class Move_Zeroes
    {
       /// <summary>
       ///  1 two pointer 左移，
       /// 2 后面的置0
       /// </summary>
       /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int lastNonZeroFoundAt = 0;
            // If the current element is not 0, then we need to
            // append it just in front of last non 0 element we found. 
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNonZeroFoundAt++] = nums[i];
                }
            }
            // After we have finished processing new elements,
            // all the non-zero elements are already at beginning of array.
            // We just need to fill remaining array with 0's.
            for (int i = lastNonZeroFoundAt; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        public void MoveZeroes2(int[] nums)
        {
            int index = 0;
            foreach (var n in nums)
            {
                if (n != 0)
                {
                    nums[index++] = n;
                }
            }
            while (index < nums.Length)
            {
                nums[index++] = 0;
            }
        }

    }
}
