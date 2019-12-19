using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.Heap
{
    /// <summary>
    /// <see cref="Swim_in_Rising_Water_PQ"/> 同一套模板
    /// </summary>
    class Path_With_Maximum_Minimum_Value
    {
        int[][] dirs =  { new [] { 0, 1 }, new [] { 0, -1 }, new [] { 1, 0 }, new [] { -1, 0 } };

        public int maximumMinimumPath(int[][] A)
        {
            int m = A.Length;
            int n = A[0].Length;

            SortedSet<Tuple<int, int, int>> pq = new SortedSet<Tuple<int, int, int>>(); // tuple 自动实现 compare
            pq.Add(new Tuple<int, int, int> (A[0][0], 0 , 0 ));
            var visited = new bool[m,n];
            visited[0,0] = true;

            int res = A[0][0];
            while (pq.Any())
            {
                var cur = pq.Max;  // 一直去加最大的
                pq.Remove(cur);
                res = Math.Min(res, cur.Item1);
                if (cur.Item2 == m - 1 && cur.Item3 == n - 1)
                {
                    return res;
                }

                foreach (int[] dir in dirs)
                {
                    int x = cur.Item2 + dir[0];
                    int y = cur.Item3 + dir[1];
                    if (x < 0 || x >= m || y < 0 || y >= n || visited[x,y]) // validate
                    {
                        continue;
                    }

                    visited[x,y] = true;
                    pq.Add(new Tuple<int, int, int>(A[x][y], x, y) );
                }
            }

            return res;
        }
    }
}
