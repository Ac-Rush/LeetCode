using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Maximum_Product_of_Three_Numbers
    {
        /// <summary>
        /// Time Limit Exceeded
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct(int[] nums)
        {
            var max = int.MinValue;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length ; k++)
                    {
                        max = Math.Max(max, nums[i]*nums[j]*nums[k]);
                    }
                }
            }
            return max;
        }


        /// <summary>
        /// Using Sorting [Accepted]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct2(int[] nums)
        {
            System.Array.Sort(nums);
            return Math.Max(nums[0] * nums[1] * nums[nums.Length - 1], nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3]);
        }


        /// <summary>
        /// Single Scan [Accepted]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct3(int[] nums)
        {
            int min1 = int.MaxValue, min2 = int.MaxValue;
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
            foreach (int n in nums)
            {
                if (n <= min1)
                {
                    min2 = min1;
                    min1 = n;
                }
                else if (n <= min2)
                {     // n lies between min1 and min2
                    min2 = n;
                }
                if (n >= max1)
                {            // n is greater than max1, max2 and max3
                    max3 = max2;
                    max2 = max1;
                    max1 = n;
                }
                else if (n >= max2)
                {     // n lies betweeen max1 and max2
                    max3 = max2;
                    max2 = n;
                }
                else if (n >= max3)
                {     // n lies betwen max2 and max3
                    max3 = n;
                }
            }
            return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }
    }
}
