using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Squares_of_a_Sorted_Array
    {
        public int[] SortedSquares(int[] A)
        {
            return A.Select(i => i * i).OrderBy(i => i).ToArray();
        }
    }

    /// <summary>
    /// two pointer
    /// 因为原始数组已经有序， 左边或是右边的平方 肯定是最大的，所以用了two pointer
    /// 
    /// </summary>

    class Squares_of_a_Sorted_Array_two_pointer
    {
        public int[] SortedSquares(int[] A)
        {
            int n = A.Length;
            int[] result = new int[n];
            int i = 0, j = n - 1;
            for (int p = n - 1; p >= 0; p--)
            {
                if (Math.Abs(A[i]) > Math.Abs(A[j]))
                {
                    result[p] = A[i] * A[i];
                    i++;
                }
                else
                {
                    result[p] = A[j] * A[j];
                    j--;
                }
            }
            return result;
        }
    }

    class Squares_of_a_Sorted_Array_two_pointer_simple
    {
        public int[] SortedSquares(int[] A)
        {
            int i = 0;
            var result = new int[A.Length];
            for (int p = A.Length -1 , j = p , i = 0; p >= 0; p--)  result[p] = A[i] * A[i] > A[j] * A[j] ? A[i] * A[i++] : A[j] * A[j--];
            return result;
        }
    }
}
