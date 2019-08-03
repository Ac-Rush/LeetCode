using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    /*
     
        pproach #1: Brute Force [Accepted]
Intuition and Algorithm

Let's try to find the smallest left-most chunk. If the first k elements are [0, 1, ..., k-1], then it can be broken into a chunk, and we have a smaller instance of the same problem.

We can check whether k+1 elements chosen from [0, 1, ..., n-1] are [0, 1, ..., k] by checking whether the maximum of that choice is k.

    */
    class Max_Chunks_To_Make_Sorted
    {
        public int MaxChunksToSorted(int[] arr)
        {
            int ans = 0, max = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                max = Math.Max(max, arr[i]);
                if (max == i) ans++;
            }
            return ans;
        }
    }
}
