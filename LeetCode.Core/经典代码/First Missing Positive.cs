using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    /// <summary>
    /// 这个就是借住了 index,把正确的数放到正确的地方
    /// Put each number in its right place.

   // For example:

///When we find 5, then swap it with A[4].

///At last, the first place where its number is not right, return the place + 1.
    /// </summary>
    class First_Missing_Positive
    {
        public int FirstMissingPositive(int[] A)
        {
            //本质上是桶排序， 每当 A[i] != i+1 的时候， 将A[i]与 A[A[i] -1] 交换， 直到无法交换位置，终止条件就是 A[i] ==A[A[i] -1]
            // 这个是 正确的数 放到正确的位置的代码
            //A[i] i 当前位置的数值
            //A[A[i] - 1] 
            for (int i = 0; i < A.Length; ++i)
                while (A[i] > 0 && A[i] <= A.Length && A[A[i] - 1] != A[i])
                    Swap(A, i,A[i] - 1);

            for (int i = 0; i < A.Length; ++i)
                if (A[i] != i + 1)
                    return i + 1;

            return A.Length + 1;
        }


        public int FirstMissingPositive2(int[] A)
        {
           


            //本质上是桶排序， 每当 A[i] != i+1 的时候， 将A[i]与 A[A[i] -1] 交换， 直到无法交换位置，终止条件就是 A[i] ==A[A[i] -1]
            // 这个是 正确的数 放到正确的位置的代码
            for (int i = 0; i < A.Length; i++)
            {
                while (A[i] != i + 1)
                {
                    /*
                    * 
                    * FirstMissingPositive 是由FirstMissingPositive2 推出来的
                    *  当    A[i] == i + 1 那么  A[A[i] - 1] == A[i]
                    *  e.g. i=2 A[2] = 3  那么 A[3-1] = A[2] ,所以将两个条件合并了
                    */
                    if (A[i] <= 0 || A[i] > A.Length || A[A[i] - 1] == A[i])
                        break;
                    Swap(A, i, A[i] - 1);
                }

            }

            for (int i = 0; i < A.Length; ++i)
                if (A[i] != i + 1)
                    return i + 1;

            return A.Length + 1;
        }

        private void Swap(int[] nums, int i, int j)
        {
            var t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }
    }
}
