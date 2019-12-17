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

    /// <summary>
    /// 这个是最棒的解法， 用了Deque， C#可以用 LinkedList， 使用了单调栈的原理， 此处是单调递减栈
    /// 单调队列原理
    /// </summary>
    class Sliding_Window_Maximum_ON_2
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 1) return nums;

            int[] result = new int[nums.Length - (k - 1)];
            LinkedList<int> win = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (win.Count != 0 && win.First.Value < i - (k - 1)) win.RemoveFirst(); // 去掉范围外的数

                while (win.Count != 0 && nums[win.Last.Value] <= nums[i]) win.RemoveLast(); // 保证单调 去掉栈里比当前小的

                win.AddLast(i);  //加入栈 /注意栈里的元素是坐标，

                if (i >= k - 1) result[i - (k - 1)] = nums[win.First.Value]; // 存储结果， 栈头元素是最大的
            }

            return result;
        }
    }



    public class Sliding_Window_Maximum_ON_MonotonicQueue
    {
        /// <summary>
        /// 单调队列 模板
        /// </summary>
        public class MonotonicQueue
        {
            LinkedList<int> qu;

            public MonotonicQueue()
            {
                qu = new LinkedList<int>();
            }
            public int Max()
            {
                if (!qu.Any()) return -1;
                return qu.First.Value;
            }
            public void Pop()
            {
                if (qu.Any()) qu.RemoveFirst();
            }
            public void Push(int val)
            {
                while (qu.Any() && qu.Last.Value < val)
                {
                    qu.RemoveLast();
                }

                qu.AddLast(val);
            }
        }
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 1) return nums;

            int[] res = new int[nums.Length - (k - 1)];
            int idx = 0;
            MonotonicQueue qu = new MonotonicQueue();
            for (int i = 0; i < nums.Length; i++)
            {
                qu.Push(nums[i]);
                if (i - k + 1 >= 0)
                {
                    res[idx++] = qu.Max();
                    if (nums[i - k + 1] == qu.Max())
                    {
                        qu.Pop();
                    }

                }
            }

            return res;
        }
    }
}
