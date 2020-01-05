using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    /// <summary>
    /// https://leetcode.com/problems/merge-sorted-array/description/
    /// </summary>
    class Merge_Sorted_Array
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i > -1 && j > -1) nums1[k--] = (nums1[i] > nums2[j]) ? nums1[i--] : nums2[j--];
            while (j > -1) nums1[k--] = nums2[j--];
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            var index = m + n - 1;
            m--; n--;
            while (n >= 0)
            {
                if (m < 0) { nums1[index--] = nums2[n--]; }
                else
                {
                    nums1[index--] = nums1[m] > nums2[n] ? nums1[m--] : nums2[n--];
                }
            }
        }
    }
}
