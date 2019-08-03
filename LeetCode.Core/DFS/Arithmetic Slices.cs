using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Arithmetic_Slices
    {
        public int NumberOfArithmeticSlices(int[] A)
        {
            int cur = 0, sum = 0;
            for (int i = 2; i < A.Length; i++)
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    cur += 1;
                    sum += cur;
                }
                else
                {
                    cur = 0;
                }
            return sum;
        }
    }
}
