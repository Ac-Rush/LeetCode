using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Sort_Array_By_Parity_II
    {
        /// <summary>
        /// 这个不是太直接， 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SortArrayByParityII(int[] A)
        {
            int e = 0;
            int o = 1;

            while (e < A.Length && o < A.Length)
            {
                if (A[e] % 2 != 0)
                {
                    //换完， o也不见得是偶数，所以这边的e不加2， 进到下次的 while， 总之能使 e最终是偶数
                    var t = A[o];
                    A[o] = A[e];
                    A[e] = t;
                    o += 2;
                }
                else
                {
                    e += 2;
                }
            }

            return A;
        }
    }
    /// <summary>
    /// 双指针更好理解版本
    /// 就像partition， 找到两个不符合要求的交换
    /// </summary>
    class Sort_Array_By_Parity_II_v2
    {
        public int[] SortArrayByParityII(int[] A)
        {
            int i = 0, j = 1, n = A.Length;
            while (i < n && j < n)
            {
                while (i < n && A[i] % 2 == 0) i += 2;
                while (j < n && A[j] % 2 == 1) j += 2;
                if (i < n && j < n) //my bug还需要 这里的判断
                {
                    Swap(A, i, j);
                }
            }
            return A;
        }
        private void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
