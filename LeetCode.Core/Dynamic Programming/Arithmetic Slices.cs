using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Arithmetic_Slices
    {
        public int NumberOfArithmeticSlices(int[] A)
        {
            if (A == null || A.Length < 3)
            {
                return 0;
            }
            var count = 0;
            var curLength = 2;

            for (int i = 2; i < A.Length; i++)
            {
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    curLength++;
                    count = count + curLength - 2;
                }
                else
                {
                    curLength = 2;
                }
            }
            return count;
        }

        /// <summary>
        /// Using Formula [Accepted]:
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>

        public int NumberOfArithmeticSlices2(int[] A)
        {
            int count = 0;
            int sum = 0;
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    count++;
                }
                else
                {
                    sum += (count + 1) * (count) / 2;
                    count = 0;
                }
            }
            return sum += count * (count + 1) / 2;
        }
    }
}
