using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.DAC
{
    class Count_of_Smaller_Numbers_After_Self
    {/// <summary>
    /// 从后向前 一个个二分查找，并插入到有序数组里，  O（N^2）
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
        public IList<int> CountSmaller(int[] nums)
        {
            var ans = new int[nums.Length];
            List<int> sorted = new List<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int index = findIndex(sorted, nums[i]);
                ans[i] = index;
                sorted.Insert(index, nums[i]);
            }
            return ans.ToList();
        }
        private int findIndex(List<int> sorted, int target)
        {
            if (sorted.Count == 0) return 0;
            int start = 0;
            int end = sorted.Count - 1;
            if (sorted[end] < target) return end + 1;
            if (sorted[start] >= target) return 0;
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (sorted[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            if (sorted[start] >= target) return start;
            return end;
        }
    }

    class Count_of_Smaller_Numbers_After_Self_NLogN
    {
    }
}
