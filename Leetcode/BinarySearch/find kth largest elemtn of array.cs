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
            var p = Partition(a, lo, hi); // p就是数组的小标，  k就是第几个， k不需要 根据p去变化
            // pivot is the one!
            if (p == k -1) return p;
            // pivot is too big, so it must be on the left
            else if (p > k -1 ) return quickSelect(a, lo, p - 1, k);
            // pivot is too small, so it must be on the right
            else return quickSelect(a, p + 1, hi, k );
        }

        private int Partition(int[] a, int lo, int hi)
        {
           //分成 三份， [lo, i) , i (i,j);  (i,j) 是没有判断过的， [j,end]是比 pivot大于等于的
            int i = lo, j = hi, pivot = a[hi];
            while (i < j)
            {
                if (a[i++] > pivot) swap(a, --i, --j);  // 是 --i, --j， --i是后悔了，还是计算上一个， --j是 不从end开始， 从end减1开始，
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
