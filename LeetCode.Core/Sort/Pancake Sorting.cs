using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Pancake_Sorting
    {
        /// <summary>
        /// 因为数组内容是有条件的 A[i]<= A.Length , 并且 全部都有。
        /// 所以每次都把最大的 移动到尾部 两次反转，
        ///     1. 把最大的 移到头部
        ///     2.把最大的移到尾部  相对尾部
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<int> PancakeSort(int[] A)
        {
            List<int> res = new List<int> ();
            for (int x = A.Length, i; x > 0; --x)
            {
                for (i = 0; A[i] != x; ++i) ;
                reverse(A, i + 1);
                res.Add(i + 1);
                reverse(A, x);
                res.Add(x);
            }
            return res;
        }

        public void reverse(int[] A, int k)
        {
            for (int i = 0, j = k - 1; i < j; i++, j--)
            {
                int tmp = A[i];
                A[i] = A[j];
                A[j] = tmp;
            }
        }
    }
}
