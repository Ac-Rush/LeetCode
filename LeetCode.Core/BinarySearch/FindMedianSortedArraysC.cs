using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class FindMedianSortedArraysC
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int first = (nums1.Length + nums2.Length + 1) >> 1;
            int second = (nums1.Length + nums2.Length + 2) >> 1;
            return (FindK(nums1, nums2, 0, 0, first) + FindK(nums1, nums2, 0, 0, second)) / 2.0;
        }

        private static int FindK(int[] nums1, int[] nums2, int start1, int start2, int k)
        {
            if (nums1.Length - start1 > nums2.Length - start2)
                return FindK(nums2, nums1, start2, start1, k);
            if (start1 == nums1.Length)
            {
                return nums2[start2 + k -1];
            }

            if (k == 1)
            {
                return Math.Min(nums1[start1], nums2[start2]);
            }

            int i = Math.Min(k / 2 + start1, nums1.Count() ) , j = k - i + start2 + start1;

            if (nums1[i - 1] < nums2[j - 1])
                return FindK(nums1, nums2,  i, start2, k - i + start1);
            else if (nums1[i - 1] >= nums2[j - 1])
                return FindK(nums1, nums2, start1,  j, k - j + start2);
            return 0;
        }

        /// <summary>
        /// solution 2
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public double findMedianSortedArrays2(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            if (m > n)
            { // to ensure m<=n
                int[] temp = A; A = B; B = temp;
                int tmp = m; m = n; n = tmp;
            }
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;
                if (i < iMax && B[j - 1] > A[i])
                {
                    iMin = iMin + 1; // i is too small
                }
                else if (i > iMin && A[i - 1] > B[j])
                {
                    iMax = iMax - 1; // i is too big
                }
                else
                { // i is perfect
                    int maxLeft = 0;
                    if (i == 0) { maxLeft = B[j - 1]; }
                    else if (j == 0) { maxLeft = A[i - 1]; }
                    else { maxLeft = Math.Max(A[i - 1], B[j - 1]); }
                    if ((m + n) % 2 == 1) { return maxLeft; }

                    int minRight = 0;
                    if (i == m) { minRight = B[j]; }
                    else if (j == n) { minRight = A[i]; }
                    else { minRight = Math.Min(B[j], A[i]); }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }


       
    }
}
