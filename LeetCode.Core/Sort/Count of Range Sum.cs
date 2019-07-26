using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    /*  不太会这个
     * 
     * 
   Recall count smaller number after self where we encountered the problem

count[i] = count of nums[j] - nums[i] < 0 with j > i
Here, after we did the preprocess, we need to solve the problem

count[i] = count of a <= S[j] - S[i] <= b with j > i
ans = sum(count[:])

        Therefore the two problems are almost the same. We can use the same technique used in that problem to solve this problem. 
        One solution is merge sort based; another one is Balanced BST based. The time complexity are both O(n log n).

The merge sort based solution counts the answer while doing the merge. 
During the merge stage, we have already sorted the left half [start, mid) and right half [mid, end).
We then iterate through the left half with index i. For each i, we need to find two indices k and j in the right half where

j is the first index satisfy sums[j] - sums[i] > upper and
k is the first index satisfy sums[k] - sums[i] >= lower.
Then the number of sums in [lower, upper] is j-k. We also use another index t to copy the elements satisfy sums[t] < sums[i] to a cache in order to complete the merge sort.

Despite the nested loops, the time complexity of the "merge & count" stage is still linear. Because the indices k, j, t will only increase but not decrease, each of them will only traversal the right half once at most. 
The total time complexity of this divide and conquer solution is then O(n log n).

One other concern is that the sums may overflow integer. So we use long instead.

    */
    class Count_of_Range_Sum_MergeSort
    {
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            int n = nums.Length;
            long[] sums = new long[n + 1];
            for (int i = 0; i < n; ++i)
                sums[i + 1] = sums[i] + nums[i];
            return countWhileMergeSort(sums, 0, n + 1, lower, upper);
        }
        private int countWhileMergeSort(long[] sums, int start, int end, int lower, int upper)
        {
            if (end - start <= 1) return 0;
            int mid = (start + end) / 2;
            int count = countWhileMergeSort(sums, start, mid, lower, upper)
                      + countWhileMergeSort(sums, mid, end, lower, upper);
            int j = mid, k = mid, t = mid;
            long[] cache = new long[end - start];
            for (int i = start, r = 0; i < mid; ++i, ++r)
            {
                while (k < end && sums[k] - sums[i] < lower) k++; //第一个差值 大于等于 lower
                while (j < end && sums[j] - sums[i] <= upper) j++;//第一个差值 大于  upper
                while (t < end && sums[t] < sums[i]) cache[r++] = sums[t++];  //如果t小 那么负值t，
                cache[r] = sums[i];  //然后负值i
                count += j - k;  //然后计算 count
            }
            System.Array.Copy(cache, 0, sums, start, t - start);//t 应该是 最后一个需要变动的值
            return count;
        }
    }


    /// <summary>
    /// Time Limit Exceeded  N^2
    /// </summary>
    class Count_of_Range_Sum_Naive
    {
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            int n = nums.Length;
            long[] sums = new long[n + 1]; // prefix sun数组
            for (int i = 0; i < n; ++i)
                sums[i + 1] = sums[i] + nums[i];
            int ans = 0;
            for (int i = 0; i < n; ++i)
                for (int j = i + 1; j <= n; ++j)
                    if (sums[j] - sums[i] >= lower && sums[j] - sums[i] <= upper) //每两个点 check一下 prefix sum
                        ans++;
            return ans;
        }
    }
}
