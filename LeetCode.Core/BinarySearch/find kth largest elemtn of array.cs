using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class find_kth_largest_elemtn_of_arrayC
    {
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

        private int Partition(int[] a, int lo, int hi)
        {
            int i = lo, j = hi, pivot = a[hi];
            while (i < j)
            {
                if (a[i++] > pivot) swap(a, --i, --j);
            }
            swap(a, i, hi);

            // count the nums that are <= pivot from lo

            return i;
        }
        void swap(int[] a, int i, int j)
        {
            int tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}
