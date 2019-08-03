using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Swim_in_Rising_Water
    {
         static int[][] steps = new int[][] {new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }};
        /// <summary>
        /// DP + DFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int SwimInWater(int[,] grid)
        {
            var height = grid.GetLength(0);
            var weight = grid.GetLength(1);
            var max = new int[height, weight] ;
            for (int index00 = 0; index00 < max.GetLength(0); index00++)
                for (int index01 = 0; index01 < max.GetLength(1); index01++)
                {
                    max[index00, index01] = int.MaxValue;
                }
            dfs(grid, max, 0, 0, grid[0,0]);
            return max[height - 1, weight - 1];
        }

        private void dfs(int[,] grid, int[,] max, int x, int y, int cur)
        {
            int n = grid.GetLength(0);
            if (x < 0 || x >= n || y < 0 || y >= n || Math.Max(cur, grid[x,y]) >= max[x,y])
                return;
            max[x,y] = Math.Max(cur, grid[x,y]);
            foreach (var s in steps)
            {
                dfs(grid, max, x + s[0], y + s[1], max[x,y]);
            }
        }

        
    }
}
