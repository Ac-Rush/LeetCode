using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    /// <summary>
    /// 哈哈哈哈， my solution 一次过， 就是用了 PQ, 
    /// </summary>
    class Sliding_Window_Maximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length < k || k <=0) //my bug 之前没有判断 k<=0
            {
                return new int[0];
            }
             var ans = new int[nums.Length - k + 1];
            SortedSet<int[]> max = new SortedSet<int[]>(Comparer<int[]>.Create((a,b) => a[0]==b[0]? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0])));
            int i = 0;

            for (; i < k -1; i++)
            {
                max.Add(new int[] {nums[i], i});
            }
            var index = 0;
            for (; i < nums.Length; i++)
            {
                max.Add(new int[] { nums[i], i });
                var maxItem = max.Max;
                ans[index++] = maxItem[0];
                max.Remove(new int[] {nums[i-k +1], i-k +1});
            }
            return ans;
        }
    }

    /*
     For Example: A = [2,1,3,4,6,3,8,9,10,12,56], w=4

partition the array in blocks of size w=4. The last block may have less then w.
2, 1, 3, 4 | 6, 3, 8, 9 | 10, 12, 56|

Traverse the list from start to end and calculate max_so_far. Reset max after each block boundary (of w elements).
left_max[] = 2, 2, 3, 4 | 6, 6, 8, 9 | 10, 12, 56

Similarly calculate max in future by traversing from end to start.
right_max[] = 4, 4, 4, 4 | 9, 9, 9, 9 | 56, 56, 56

now, sliding max at each position i in current window, sliding-max(i) = max{right_max(i), left_max(i+w-1)}
sliding_max = 4, 6, 6, 8, 9, 10, 12, 56

    */
    class Sliding_Window_Maximum_ON
    {
        public int[] MaxSlidingWindow(int[] nums, int w)
        {
            var queue = new Queue<int>();
            
            var max_left = new int[nums.Length];
            var max_right = new int[nums.Length];

            max_left[0] = nums[0];
            max_right[nums.Length - 1] = nums[nums.Length - 1];

            for (var i = 1; i < nums.Length; i++)
            {
                max_left[i] = (i%w == 0) ? nums[i] : Math.Max(max_left[i - 1], nums[i]);

                var j = nums.Length - i - 1;
                max_right[j] = (j%w == 0) ? nums[j] : Math.Max(max_right[j + 1], nums[j]);
            }

            var sliding_max = new int[nums.Length - w + 1];
            for (int i = 0, j = 0; i + w <= nums.Length; i++)
            {
                sliding_max[j++] = Math.Max(max_right[i], max_left[i + w - 1]);
            }

            return sliding_max;
        }
    }


}
