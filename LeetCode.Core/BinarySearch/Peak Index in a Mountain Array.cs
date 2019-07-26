using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Peak_Index_in_a_Mountain_Array
    {

        public int PeakIndexInMountainArray2(int[] A)
        {
            int lo = 0, hi = A.Length - 1;
            while (lo < hi)
            {
                int mi = lo + (hi - lo) / 2;
                if (A[mi] < A[mi + 1]) //lo 肯定会停留在 第一个不符合条件的
                    lo = mi + 1;
                else
                    hi = mi;
            }
            return lo;
        }

        public int peakIndexInMountainArray3(int[] A)
        {
            int i = 0;
            while (A[i] < A[i + 1]) i++;   // 上面的 lo就是这个条件
            return i;
        }

        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] A)
        {
            var l = 0;
            var r = A.Length - 1;
            while (l < r)
            {
                var mid = l + (r - l)/2;

                if (A[mid] > A[mid - 1] && A[mid] > A[mid + 1])
                {
                    return mid;
                }
                if (A[mid] > A[mid - 1] && A[mid] < A[mid + 1])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }

            }
            return -1;
        }
    }
}
