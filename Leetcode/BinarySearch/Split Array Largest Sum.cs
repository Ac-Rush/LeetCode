using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Split_Array_Largest_Sum
    {
        /// <summary>
        /// DP solution
        /// dp[s,j] is the solution for splitting subarray n[j]...n[L-1] into s parts.
        /// dp[s + 1, i] = min{ max(dp[s, j], n[i]+...+n[j - 1]) }, i+1 <= j <= L-s
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int SplitArray(int[] nums, int m)
        {
            var L = nums.Length;
            var sum = new int[L + 1];
            for (int i = 0; i < L; i++)
            {
                sum[i+1] = sum[i ] + nums[i];
              
            }
            int[] dp = new int[L];
            for (int i = 0; i < L; i++)
                dp[i] = sum[L] - sum[i];

            for (int s = 1; s < m; s++)
            {
                for (int i = 0; i < L - s; i++)
                {
                    dp[i] = int.MaxValue;
                    for (int j = i + 1; j <= L - s; j++)
                    {
                        int t = Math.Max(dp[j], sum[j] - sum[i]);
                        if (t <= dp[i])
                            dp[i] = t;
                        else
                            break;
                    }
                }
            }

            return dp[0];
        }

        /*
         The answer is between maximum value of input array numbers and sum of those numbers.
Use binary search to approach the correct answer. We have l = max number of array; r = sum of all numbers in the array;Every time we do mid = (l + r) / 2;
Use greedy to narrow down left and right boundaries in binary search.
3.1 Cut the array from left.
3.2 Try our best to make sure that the sum of numbers between each two cuts (inclusive) is large enough but still less than mid.
3.3 We'll end up with two results: either we can divide the array into more than m subarrays or we cannot.
If we can, it means that the mid value we pick is too small because we've already tried our best to make sure each part holds as many non-negative numbers as we can but we still have numbers left. So, it is impossible to cut the array into m parts and make sure each parts is no larger than mid. We should increase m. This leads to l = mid + 1;
If we can't, it is either we successfully divide the array into m parts and the sum of each part is less than mid, or we used up all numbers before we reach m. Both of them mean that we should lower mid because we need to find the minimum one. This leads to r = mid - 1;
         */
        /// <summary>
        /// 8ms Binary Search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int SplitArray2(int[] nums, int m)
        {
            int max = 0; long sum = 0;
            foreach (var num in nums)
            {
                max = Math.Max(num, max);
                sum += num;
            }
            if (m == 1) return (int)sum;
            //binary search
            long l = max; long r = sum;
            while (l < r)
            {
                long mid = (l + r) / 2;
                if (Valid(mid, nums, m))
                {
                    r = mid;    // r的右边都是 valid, while退出后, l就是 r右边的第一个。
                }
                else
                {
                    l = mid + 1;
                }
            }
            return (int)l;
        }

        public bool Valid(long target, int[] nums, int m)
        {
            int count = 1;
            long total = 0;
            foreach (var num in nums)
            {
                total += num;
                if (total > target)
                {
                    total = num;
                    count++;
                    if (count > m)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
