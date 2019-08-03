using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Sort_Array_By_Parity
    {
        public int[] SortArrayByParity(int[] A)
        {
            var start = 0;
            var end = A.Length - 1;
            while (start < end)
            {
                if (A[start] % 2 == 0)
                {
                    start++;
                    continue;
                }
                if (A[end] % 2 == 1)
                {
                    end--;
                    continue;
                }
                var temp = A[start];
                A[start] = A[end];
                A[end] = temp;
                start++;
                end--;
            }
            return A;
        }
    }

    class Sort_Array_By_Parity_Ex
    {
        public int[] SortArrayByParity(int[] A)
        {
            var start = 0;
            var end = A.Length - 1;
            while (start < end)
            {
                if(A[start] % 2 > A[end] % 2)
                {
                    var temp = A[start];
                    A[start] = A[end];
                    A[end] = temp;
                }
                if (A[start] % 2 == 0)start++;
                if (A[end] % 2 == 1) end--;
            }
            return A;
        }
    }
}
