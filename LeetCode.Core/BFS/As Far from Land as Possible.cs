using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.BFS
{
    public class As_Far_from_Land_as_Possible
    {
        public int MaxDistance(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var queue = new Queue<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue(new[] { i, j });
                    }
                }
            }
            var step = 0;
            var dirs = new int[][] { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
            while (queue.Count > 0)
            {
                var count = queue.Count;
                while (count-- > 0)
                {
                    var p = queue.Dequeue();
                    foreach (var dir in dirs)
                    {
                        var i = p[0] + dir[0];
                        var j = p[1] + dir[1];
                        if (i < 0 || j < 0 || i >= m || j >= n || grid[i][j] == 1) continue;
                        queue.Enqueue(new[] { i, j });
                        grid[i][j] = 1;
                    }
                }
                step++;
            }
            return step;
        }
    }
}
