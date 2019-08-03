using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Find_the_Town_Judge
    {

        /*
         *
Intuition:
Consider trust as a graph, all pairs are directed edge.
The point with in-degree - out-degree = N - 1 become the judge.

Explanation:
Count the degree, and check at the end.

Time Complexity:
Time O(T + N), space O(N)
         *
         */
        public int FindJudge(int N, int[][] trust)
        {
            int[] count = new int[N + 1];
            foreach (var t in trust)
            {
                count[t[0]]--;
                count[t[1]]++;
            }
            for (int i = 1; i <= N; ++i)
            {
                if (count[i] == N - 1) return i;
            }
            return -1;
        }
    }
}
