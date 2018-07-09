using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Wiggle_Sort
    {
        public void WiggleSort(int[] nums)
        {
            bool less = true;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (less)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        Swap(nums, i, i + 1);
                    }
                }
                else
                {
                    if (nums[i] < nums[i + 1])
                    {
                        Swap(nums, i, i + 1);
                    }
                }
                less = !less;
            }
        }
     

        private int Partition(int[] a, int lo, int hi)
        {

            int i = lo, j = hi, pivot = a[hi];
            while (i < j)
            {
                if (a[i++] > pivot) Swap(a, --i, --j);
            }
            Swap(a, i, hi);

            // count the nums that are <= pivot from lo

            return i;
        }


        public int FindKthLargest(int[] a, int k)
        {
            int n = a.Length;
            int p = quickSelect(a, 0, n - 1, n - k + 1);  //largest ，所以要 n-k+1
            return a[p];
        }
        public int quickSelect(int[] a, int lo, int hi, int k)
        {
            var p = Partition(a, lo, hi);
            int m = p - lo + 1;

            // pivot is the one!
            if (m == k) return p;
            // pivot is too big, so it must be on the left
            else if (m > k) return quickSelect(a, lo, p - 1, k);
            // pivot is too small, so it must be on the right
            else return quickSelect(a, p + 1, hi, k - m);
        }

        

        private void Swap(int[] nums, int i, int j)
        {
            var t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }
    }
}
