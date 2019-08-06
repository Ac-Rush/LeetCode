using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.Sort
{
    class Sort_an_Array
    {
        private void QuickSort(int[] nums, int start, int end)
        {
            if (start >= end) return;
            var pivot = Partition(nums, start, end);
            QuickSort(nums, start , pivot -1);
            QuickSort(nums, pivot+1, end);
        }

        private int Partition(int[] nums, int lo, int hi)
        {
            int i = lo, j = hi, pivot = nums[hi];
            while (i < j)
            {
                if (nums[i++] > pivot) Swap(nums, --i, --j);
            }
            Swap(nums, i, hi);

            // count the nums that are <= pivot from lo

            return i;
        }

        private void Swap(int[] nums, int i, int j)
        {
            var t = nums[j];
            nums[j] = nums[i];
            nums[i] = t;
        }
        
        public int[] SortArray(int[] nums)
        {
            QuickSort(nums, 0, nums.Length-1);
            return nums;
        }

        public int[] SortArray2(int[] nums)
        {
            return nums.OrderBy(i=>i).ToArray();
        }
    }
}
