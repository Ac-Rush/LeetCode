using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Util;

namespace Leetcode.BinarySearch
{
    class Swim_in_Rising_Water_PQ
    {
        /// <summary>
        /// pq 解法，
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int swimInWater(int[][] grid)
        {
            int n = grid.Length;
            SortedSet<Tuple<int, int, int>> pq = new SortedSet<Tuple<int, int, int>>(); // tuple 自动实现 compare
            var visited = new bool[n,n];
            int[][] steps = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            visited[0,0] = true;
            pq.Add(new Tuple<int, int, int>(grid[0][0], 0, 0 ));
            while (pq.Any())
            {
                var info = pq.Min;
                pq.Remove(info);
                int i = info.Item2, j = info.Item3, max = info.Item1;
                foreach (int[] dir in steps)
                {
                    int newI = dir[0] + i, newJ = dir[1] + j;
                    if (newI < 0 || newI >= n || newJ < 0 || newJ >= n) continue;
                    if (!visited[newI,newJ])
                    {
                        visited[newI,newJ] = true;
                        int newmax = Math.Max(max, grid[newI][newJ]);
                        if (newI == n - 1 && newJ == n - 1) return newmax;
                        pq.Add(new Tuple<int, int, int>(newmax, newI, newJ) );
                    }
                }
            }

            return 0;
        }
    }

    class Swim_in_Rising_Water
    {







         static int[][] steps = new int[][] {new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }};
        /// <summary>
        /// DFS 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int SwimInWater(int[][] grid)
        {
            var height = grid.Length;
            var weight = grid[0].Length;
            var max = new int[height, weight];
            for (int index00 = 0; index00 < height; index00++)
            for (int index01 = 0; index01 < weight; index01++)
            {
                max[index00, index01] = int.MaxValue;
            }
            dfs(grid, max, 0, 0, grid[0][0]);
            return max[height - 1, weight - 1];
        }

        private void dfs(int[][] grid, int[,] max, int x, int y, int cur)
        {
            int n = grid.Length;
            if (x < 0 || x >= n || y < 0 || y >= n || Math.Max(cur, grid[x][y]) >= max[x, y]) // validate check
                return;
            max[x, y] = Math.Max(cur, grid[x][y]);
            foreach (var s in steps)
            {
                dfs(grid, max, x + s[0], y + s[1], max[x, y]);
            }
        }
    }
}
