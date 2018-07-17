using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    /// <summary>.
    /// Sliding Window [Accepted]
    ///The idea is to use an array days[] to record each position's flower's blooming day. That means days[i] is the blooming day of the flower in position i+1. We just need to find a subarray days[left, left+1,..., left+k-1, right] which satisfies: for any i = left+1,..., left+k-1, we can have days[left] < days[i] && days[right] < days[i]. Then, the result is max(days[left], days[right])
    // Time and Space Complexity: O(N)O(N).
    /// </summary>
    /*
     
        As in Approach #2, we have days[x] = i for the time that the flower at position x blooms. We wanted to find candidate intervals [left, right] where days[left], days[right] are the two smallest values in [days[left], days[left+1], ..., days[right]], and right - left = k + 1.

Notice that these candidate intervals cannot intersect: for example, if the candidate intervals are [left1, right1] and [left2, right2] with left1 < left2 < right1 < right2, then for the first interval to be a candidate, days[left2] > days[right1]; and for the second interval to be a candidate, days[right1] > days[left2], a contradiction.

That means whenever whether some interval can be a candidate and it fails first at i, indices j < i can't be the start of a candidate interval. This motivates a sliding window approach.
    */
    class K_Empty_Slots
    {
        public int KEmptySlots(int[] flowers, int k)
        {
            int[] days = new int[flowers.Length];
            for (int i = 0; i < flowers.Length; i++) days[flowers[i] - 1] = i + 1;// 位置在 flowers[i] - 1 第 i+1天开花
            int left = 0, right = k + 1, res = int.MaxValue;
            for (int i = 0; right < days.Length; i++)
            {
                if (days[i] < days[left] || days[i] <= days[right]) //sliding windows， 只统计 比windows 左边和右边开花晚的  //如果不符合要求 或是 i== right
                {
                    if (i == right) res = Math.Min(res, Math.Max(days[left], days[right]));   //we get a valid subarray 找个最小的天数
                    left = i;   //更新 left, right
                    right = k + 1 + i;
                }
                // else 就是 i++ 这边是 validate 
            }
            return (res == int.MaxValue) ? -1 : res;
        }
    }

    //这个方法比较好理解 用bucket k+1size
    //Bucket, 用排序， 用 k+1 size的桶， 保存并更新 桶的最大最小值， 如果是最大值，那么去check 下一个桶的最小值， 如果是最小值那么去check上一个桶的最大值、
    class K_Empty_Slots_Bucket
    {
        //flowers[i] = x 意思的第 i 天 x 开花
        public int KEmptySlots(int[] flowers, int k)
        {
            int n = flowers.Length, p = k + 1, m = n / p + 1;

            // The idea here is to create m buckets. Each bucket has a max value and min value.
            // m is flowers.length / (k + 1) + 1.
            int[] max = new int[m];
            int[] min = new int[m];

            for (int i = 0; i < m; i++)
            {
                max[i] = int.MinValue;
                min[i] = int.MaxValue;
            }

            for (int i = 0; i < n; i++) // 按天 loop
            {
                int bucket = flowers[i] / p;  // 按位置分桶

                if (flowers[i] > max[bucket])
                {
                    // If the position is larger than the max value in the bucket, update the max value.
                    max[bucket] = flowers[i];

                    // Check if the next bucket's min value has exact k flowers not blooming
                    if (bucket + 1 < m && min[bucket + 1] == flowers[i] + p)
                    {
                        return i + 1;
                    }
                }

                if (flowers[i] < min[bucket])
                {
                    min[bucket] = flowers[i];

                    if (bucket - 1 >= 0 && max[bucket - 1] == flowers[i] - p)
                    {
                        return i + 1;
                    }
                }
            }

            return -1;
        }
    }
}
