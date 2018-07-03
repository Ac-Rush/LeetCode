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
            // 这个是 正确的数 放到正确的位置的代码
            for (int i = 0; i < A.Length; ++i)
                while (A[i] > 0 && A[i] <= A.Length && A[A[i] - 1] != A[i])
                    Swap(A, i,A[i] - 1);

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
