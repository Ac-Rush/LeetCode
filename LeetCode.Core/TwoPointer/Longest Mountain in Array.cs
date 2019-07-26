using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.TwoPointer
{
    class Longest_Mountain_in_Array
    {
        public int LongestMountain(int[] A)
        {
            int N = A.Length;
            int ans = 0, start = 0;
            while (start < N)
            {
                int end = start;
                // if base is a left-boundary
                if (end + 1 < N && A[end] < A[end + 1])
                {
                    // set end to the peak of this potential mountain
                    while (end + 1 < N && A[end] < A[end + 1]) end++;

                    // if end is really a peak..
                    if (end + 1 < N && A[end] > A[end + 1])
                    {
                        // set end to the right-boundary of mountain
                        while (end + 1 < N && A[end] > A[end + 1]) end++;
                        // record candidate answer
                        ans = Math.Max(ans, end - start + 1);
                    }
                }

                start = Math.Max(end, start + 1);
            }

            return ans;
        }
    }

    class Longest_Mountain_in_Array_2
    {
        //这个其实是我的答案， 这样比较好理解
        public int LongestMountain(int[] A)
        {
            int N = A.Length, res = 0;
            int[] up = new int[N], down = new int[N];
            for (int i = N - 2; i >= 0; --i) if (A[i] > A[i + 1]) down[i] = down[i + 1] + 1;
            for (int i = 0; i < N; ++i)
            {
                if (i > 0 && A[i] > A[i - 1]) up[i] = up[i - 1] + 1;
                if (up[i] > 0 && down[i] > 0) res = Math.Max(res, up[i] + down[i] + 1);
            }
            return res;
        }
    }
}
