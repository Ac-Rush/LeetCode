using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Number_of_Islands
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        Dfs(grid, i, j);
                    }
                }
            }
            return count;
        }
        private void Dfs(char[][] image, int sr, int sc)
        {
            if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] == '0')
            {
                return;
            }
            image[sr][sc] = '0';
            Dfs(image, sr + 1, sc);
            Dfs(image, sr, sc + 1);
            Dfs(image, sr - 1, sc);
            Dfs(image, sr, sc - 1);
        }
    }
}
