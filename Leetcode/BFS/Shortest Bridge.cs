using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Shortest_Bridge
    {
        public int ShortestBridge(int[][] A)
        {
            var ans = 1;
            if (A.Length == 0 || A[0].Length == 0) return ans;
            int r = A.Length, c = A[0].Length;
            var queue = new Queue<int[]>();
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (A[i][j] == 1) queue.Enqueue(new int[] { i, j });
                }
            }
            var dirs = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            while (queue.Count > 0)
            {
                var count = queue.Count;
                while (count-- > 0)
                {
                    var point = queue.Dequeue();
                    var min = int.MaxValue;
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        int rr = point[0] + dirs[0], cc = point[1] + dirs[1];
                        if (rr < 0 || cc < 0 || rr >= r || cc >= c) continue;
                        if (A[rr][cc] == 0) { A[rr][cc] = A[point[0]][point[1]] + 1; }
                        else
                        {
                            min = Math.Min(min, A[rr][cc]);
                        }
                    }
                    if (min != int.MaxValue) return min + A[point[0]][point[1]] - 2;
                }
            }
            return ans;
        }
    }
}
