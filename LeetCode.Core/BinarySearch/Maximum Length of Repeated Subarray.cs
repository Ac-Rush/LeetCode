using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class Maximum_Length_of_Repeated_Subarray
    {
        public static int FindLength(int[] A, int[] B)
        {
            var max = 0;
            var table = new int[A.Length + 1, B.Length + 1];
            for (var i = 0; i < A.Length; i++)
            {
                for (var j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j])
                    {
                        table[i + 1, j + 1] = table[i, j] + 1;
                        max = Math.Max(max, table[i + 1, j + 1]);
                    }
                }
            }
            return max;
        }
    }
}
