using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Maximum_Average_Subarray_I
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            var sum = 0; var maxSum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            maxSum = sum;

            for (int i = k; i < nums.Length; i++)
            {
                sum = sum + nums[i] - nums[i - k];
                maxSum = Math.Max(maxSum, sum);
            }
            return (double)maxSum / k;
        }
    }
}
