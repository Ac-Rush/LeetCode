using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.模板
{
    /// <summary>
    /// 单调递减栈
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
            return qu.First.Value;  //单调栈 最前面的就是最大的
        }
        public void Pop()
        {
            if (qu.Any()) qu.RemoveFirst();  //去掉头
        }
        public void Push(int val)  // 加入队尾
        {
            while (qu.Any() && qu.Last.Value < val)  //保持单调， 去掉依次去掉比当前小的
            {
                qu.RemoveLast();
            }

            qu.AddLast(val);  //加入队尾
        }


    }


    public class App
    {
        /// <summary>
     /// Sliding Window Maximum  应用
     /// </summary>
     /// <param name="nums"></param>
     /// <param name="k"></param>
     /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 1) return nums;

            int[] res = new int[nums.Length - (k - 1)];
            int idx = 0;
            MonotonicQueue qu = new MonotonicQueue();
            for (int i = 0; i < nums.Length; i++)
            {
                qu.Push(nums[i]);  // 加入队尾
                if (i - k + 1 >= 0)  //从第k个才能算
                {
                    res[idx++] = qu.Max();  // 记录max
                    if (nums[i - k + 1] == qu.Max()) //如果max和最开始相同 删掉
                    {
                        qu.Pop();
                    }

                }
            }

            return res;
        }
    }
}
