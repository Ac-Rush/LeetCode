using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Sort_Array_By_Parity_II
    {
        public int[] SortArrayByParityII(int[] A)
        {
            int e = 0;
            int o = 1;

            while (e < A.Length && o < A.Length)
            {
                if (A[e] % 2 != 0)
                {
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
}
