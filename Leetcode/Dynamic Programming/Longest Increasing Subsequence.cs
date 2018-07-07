using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Longest_Increasing_Subsequence
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-increasing-subsequence/description/
        /// O(n^2)
        /// 其中dp[i]表示以nums[i]为结尾的最长递增子串的长度，对于每一个nums[i]，我们从第一个数再搜索到i，如果发现某个数小于nums[i]，我们更新dp[i]，更新方法为dp[i] = max(dp[i], dp[j] + 1)，
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            var d = new int[nums.Length ];
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                d[i] = 1;  //my bug 这个需要初始化一下
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && d[j] + 1 > d[i])
                    {
                        d[i] = d[j] + 1;
                    }
                }
                res = Math.Max(res, d[i]);
            }
            return res;
        }

        /// <summary>
        /// Approach #4 Dynamic Programming with Binary Search[Accepted]:
        /// This dp array is meant to store the increasing subsequence formed by including the currently encountered element. 
        /// 首先考虑一种情况，如果dp[i]==d[j]，但是num[i]<num[j]，那么我们选择那个好呢，显然，选择以num[i]为结尾的序列更优潜力，
        /// 因为可能存在一个k，使得num[i] < num[k] < num[j]，可以使以num[i]为结尾的序列变长，但却不能使以num[j]为结尾的序列边长。
        /// 那么我们如果知道长度为i的所有序列中结尾数字最小的那个数，就可以知道能否得到一个更长的序列，设用d[i]表示长度为i的序列结尾的最小数字，那么我们就可以维护这个数组，
        /// 来求得最长公共子序列的长度。
        /// 
        /// 
        /// 
        /// follow up 如何得到最长递增序列
        /// 需要两个数组，
        /// result数组 来保存这个数之前的前序
        /// 
        /// 
        /// O(NLogN)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LengthOfLIS2(int[] nums)
        {
            // dp[i]的 含义是 长度为i的 递增序列 最小结尾是 dp[i]
            int[] dp = new int[nums.Length];  //这个结果并不是最终的递增序列结果，只是一个记录而已
            int len = 0;
            foreach (var num in nums)
            {
                //Arrays.binarySearch() method returns index of the search key, if it is contained in the array, else it returns (-(insertion point) - 1)
                int i = System.Array.BinarySearch(dp, 0, len, num);
                if (i < 0)
                {
                    i = -(i + 1);  //下一个比它大的值
                }
                dp[i] = num; //这个还就得放这里
                if (i == len)
                {
                    len++;
                }
            }
            return len;
        }


        public static int lengthOfLIS3(int[] nums)
        {
            if (nums == null || nums.Length == 0) {return 0; }
            int[] dp = new int[nums.Length+1];
            int len = 1;
            dp[1] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if ( nums[i] > dp[len])
                {
                    len++;
                    dp[len] = nums[i];
                }
                else
                {
                    int pos = findFirstLargeEqual(dp, 1, len, nums[i]);
                    dp[pos] = nums[i];
                }
            }
            return len;
        }

        private static int findFirstLargeEqual(int[] seq, int l, int r, int target)
        {
            int lo = l;
            int hi = r;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (seq[mid] < target) lo = mid + 1;
                else hi = mid;
            }

            return lo;
        }

        /// <summary>
        /// 比较好理解的做法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int lengthOfLIS4(int[] nums)
        {
            if (nums == null || nums.Length == 0) { return 0; }
            int[] dp = new int[nums.Length];
            int len = 0;
            foreach (var num in nums)
            {
                int l = 0, h = len;
                while (l < h)
                {
                    var mid = l + (h - l) / 2;
                    if (dp[mid] < num)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        h = mid;
                    }
                }
                dp[l] = num;
                if (l == len)
                {
                    len++;
                }
            }
            
            return len;
        }

    }
}
