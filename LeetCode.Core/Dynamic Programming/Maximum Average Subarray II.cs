using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Maximum_Average_Subarray_II
    {

        /// (nums[i]+nums[i+1]+...+nums[j])/(j-i+1)>x
        //=>nums[i]+nums[i + 1]+...+nums[j]>x*(j-i+1)
        //=>(nums[i]-x)+(nums[i + 1]-x)+...+(nums[j]-x)>0
        public double FindMaxAverage(int[] nums, int k)
        {
            double l = int.MinValue, r = int.MaxValue;
            while (r - l > 0.000004) //Binary search the answer
            {
                double mid = (l + r) / 2;
                if (check(nums, k, mid)) l = mid; else r = mid;
            }
            return r;
        }

        bool check(int[] nums, int k, double x) //Check whether we can find a subarray whose average is bigger than x
        {
            int n = nums.Length;
            double[] a = new double[n];
            for (int i = 0; i < n; i++) a[i] = nums[i] - x; //Transfer to a[i], find whether there is a subarray whose sum is bigger than 0
            double now = 0, last = 0;
            for (int i = 0; i < k; i++) now += a[i];
            if (now >= 0) return true;
            for (int i = k; i < n; i++)
            {
                now += a[i];
                last += a[i - k];
                if (last < 0)
                {
                    now -= last;
                    last = 0;
                }
                if (now >= 0) return true;
            }
            return false;
        }


        /// <summary>
        /// Approach #2 Using Binary Search [Accepted]
        /// (nums[i]+nums[i+1]+...+nums[j])/(j-i+1)>x
        //=>nums[i]+nums[i + 1]+...+nums[j]>x*(j-i+1)
        //=>(nums[i]-x)+(nums[i + 1]-x)+...+(nums[j]-x)>0
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverage1(int[] nums, int k)
        {
            double l = int.MinValue, r = int.MaxValue;
            while (r - l > 0.000004) //Binary search the answer
            {
                double mid = (l + r) / 2;
                if (check1(nums, mid, k )) l = mid; else r = mid;
            }
            return r;
        }


        public bool check1(int[] nums, double mid, int k)   //Check whether we can find a subarray whose average is bigger than x
        {
            double sum = 0, prev = 0, min_sum = 0;
            for (int i = 0; i < k; i++)
                sum += nums[i] - mid;
            if (sum >= 0)
                return true;
            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i] - mid;
                prev += nums[i - k] - mid;
                min_sum = Math.Min(prev, min_sum);
                if (sum >= min_sum)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// my DP solution  Time Limit Exceeded 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverageDP(int[] nums, int k)
        {
            var n = nums.Length;
            
            var dp = new int[n + 1, n + 1];
            var maxAve = double.MinValue;  //my bug
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    dp[i, j] = dp[i - 1, j - 1] + nums[j - 1];
                    if (i >= k)
                    {
                        maxAve = Math.Max(maxAve, ((double)dp[i, j])/i);
                    }
                }
            }
            return maxAve;
        }
    }
}
