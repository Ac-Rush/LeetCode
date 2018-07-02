using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class Minimum_Size_Subarray_Sum_ON
    {
        /// <summary>
        /// my solution
        /// 
        /// 双指针的 O（N）解法，
        /// J一直向右走，
        /// 如果大于 sum i向右走， 
        ///  取值区间是 i...j
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MinSubArrayLen(int s, int[] a)
        {
            if (a == null || a.Length == 0)
                return 0;

            int i = 0, j = 0, sum = 0, min = int.MaxValue;

            while (j < a.Length)
            {
                sum += a[j++];

                while (sum >= s)
                {
                    min = Math.Min(min, j - i);
                    sum -= a[i++];
                }
            }

            return min == int.MaxValue ? 0 : min;
        }
    }


    public class Minimum_Size_Subarray_Sum_N2
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
            return minLens == Int32.MaxValue ? 0 : minLens;
        }
    }
}
