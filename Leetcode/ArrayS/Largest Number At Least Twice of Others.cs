using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{

    /// <summary>
    /// https://leetcode.com/problems/largest-number-at-least-twice-of-others/description/
    /// </summary>
    class Largest_Number_At_Least_Twice_of_Others
    {
        public int DominantIndex(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return 0;
            }
            int maxIndex;
            int max, secondMax;
            if (nums[0] > nums[1])
            {
                max = nums[0];
                secondMax = nums[1];
                maxIndex = 0;
            }
            else
            {
                max = nums[1];
                secondMax = nums[0];
                maxIndex = 1;
            }
            for (int i = 2; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    secondMax = max;
                    max = nums[i];
                    maxIndex = i;
                }
                else if(secondMax < nums[i])
                {
                    secondMax = nums[i];
                }
            }
            return max >= 2 * secondMax ? maxIndex : -1;
        }

        public int DominantIndex2(int[] nums)
        {
            int maxIndex = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] > nums[maxIndex])
                    maxIndex = i;
            }
            for (int i = 0; i < nums.Length; ++i)
            {
                if (maxIndex != i && nums[maxIndex] < 2 * nums[i])
                    return -1;
            }
            return maxIndex;
        }

        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DominantIndex3(int[] nums)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return 0;
            var max = nums[0] > nums[1] ? 0 : 1;
            var secondMax = 1 - max;

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] > nums[max])
                {
                    secondMax = max;
                    max = i;
                }
                else if (nums[i] > nums[secondMax])
                {
                    secondMax = i;
                }
            }
            if (nums[max] - nums[secondMax] - nums[secondMax] >= 0)
            {
                return max;
            }
            return -1;
        }

    }
}
