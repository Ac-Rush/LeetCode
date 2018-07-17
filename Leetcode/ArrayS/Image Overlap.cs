using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    /*
     * 
     If we do brute force, we have 2N horizontal possible sliding, 2N vertical sliding and N^2 to count overlap area.
We get O(N^4) solution and it may get accepted.
But we waste out time on case of sparse matrix.

Explanation:
Assume index in A and B is [0, N * N -1].

Loop on A, if value == 1, save a coordinates i / N * 100 + i % N to LA.
Loop on B, if value == 1, save a coordinates i / N * 100 + i % N to LB.
Loop on combination (i, j) of LA and LB, increase count[i - j] by 1.
If we slide to make A[i] orverlap B[j], we can get 1 point.
Loop on count and return max values.
I use a 1 key hashmap. Assume ab for row and cd for col, I make it abcd as coordinate.
For sure, hashmap with 2 keys will be better for understanding.

Time Complexity:
O(AB)

    */
    class Image_Overlap
    {
        public int LargestOverlap(int[][] A, int[][] B)
        {
            int N = A.Length;
            List<int> LA = new List<int>();
            List<int> LB = new List<int>();
            Dictionary<int, int> count = new Dictionary<int, int>();
            for (int i = 0; i < N * N; ++i) if (A[i / N][i % N] == 1) LA.Add(i / N * 100 + i % N);
            for (int i = 0; i < N * N; ++i) if (B[i / N][i % N] == 1) LB.Add(i / N * 100 + i % N);
            foreach (int i in LA)
                foreach (int j in LB)
                {
                    if (!count.ContainsKey((i - j)))
                    {
                        count[i - j] = 0;
                    }
                    count[i - j]++;
                }
            int res = 0;
            foreach (int i in count.Values) res = Math.Max(res, i);
            return res;
        }
    }
}
