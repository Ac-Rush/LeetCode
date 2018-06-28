using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Median_of_Two_Sorted_ArraysC
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int first = (nums1.Length + nums2.Length + 1) >> 1;   //如何去 中间的第一个数
            int second = (nums1.Length + nums2.Length + 2) >> 1;//如何去 中间的第二个数
            return (FindK(nums1, nums2, 0, 0, first) + FindK(nums1, nums2, 0, 0, second)) / 2.0;
        }

        public static int FindK(int[] nums1, int[] nums2, int start1, int start2, int k)
        {
            if (nums1.Length - start1 > nums2.Length - start2)  //短的在前面，以便后面统一处理
                return FindK(nums2, nums1, start2, start1, k);

            if (start1 == nums1.Length)  //第二组比第一组长， 只处理1的情况
            {
                return nums2[start2 + k - 1];
            }
            if (k == 1)   // 这是一个终止条件， 必须要单独出来
            {
                return Math.Min(nums1[start1], nums2[start2]);
            }
            // i 要对 1的长度进行check                         //如何计算 j的index,  i = k/2+start1,  j =  k- (i-start1) + start2
            int i = Math.Min(k / 2 + start1, nums1.Count()), j = k - i + start2 + start1;
            //因为要保证第k个不被移除， 所以要减一？
            if (nums1[i - 1] < nums2[j - 1])
                return FindK(nums1, nums2, i, start2, k - i + start1);
            else
                return FindK(nums1, nums2, start1, j, k - j + start2);
        }
    }
}
