using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class Minimum_Size_Subarray_Sum
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MinSubArrayLen(int s, int[] nums)
        {
            var minLens = int.MaxValue;
            var startIndex = 0;
            var curSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                curSum += nums[i];
                if (curSum >= s)
                {
                    while (curSum >= s)
                    {
                        var curLen = i - startIndex + 1;
                        if (minLens > curLen)
                        {
                            minLens = curLen;
                        }
                        curSum = curSum - nums[startIndex++];
                    }
                }
            }
            return minLens == Int32.MaxValue ?  0:minLens;
        }
    }
}
