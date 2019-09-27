using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.模板
{
    public class UpperLowerBound
    {
        /// <summary>
        /// lower_bound( begin,end,num)：从数组的begin位置到end-1位置二分查找第一个大于或等于num的数字，找到返回该数字的地址，不存在则返回end。通过返回的地址减去起始地址begin,得到找到数字在数组中的下标。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int LowerBound(int[] a, int x)
        {
            int l = 0;
            int h = a.Length; // Not n - 1 //因为找不到要返回end
            while (l < h)
            {
                int mid = (l + h) / 2;
                if (a[mid] >= x) // 找第一个大于等于的
                {
                    h = mid; // 最后 l和h相等， 满足这样的情况 h不变， 就是要找满足这样的情况
                }
                else
                {
                    l = mid + 1;
                }
                
            }
            return l;
        }

        /// <summary>
        /// upper_bound( begin,end,num)：从数组的begin位置到end-1位置二分查找第一个大于num的数字，找到返回该数字的地址，不存在则返回end。通过返回的地址减去起始地址begin,得到找到数字在数组中的下标。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UperBound(int[] a, int x)
        {
            int l = 0;
            int h = a.Length; // Not n - 1//因为找不到要返回end
            while (l < h)
            {
                int mid = (l + h) / 2;
                if (a[mid]> x)
                {
                    h = mid;
                }
                else // 找第一个大于等于的
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}
