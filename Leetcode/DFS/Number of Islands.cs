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
        public int NumIslands(char[,] grid)
        {
            var count = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '1')
                    {
                        count++;
                        DfsDistory(grid,i,j);
                    }
                }
            }
            return count;
        }

        public void DfsDistory(char[,] grid, int r, int c)
        {
            if (grid[r, c] == '1')
            {
                grid[r, c] = '0';
                if (r > 0) DfsDistory(grid, r - 1, c);
                if (r < grid.GetLength(0) - 1) DfsDistory(grid, r + 1, c);
                if (c > 0) DfsDistory(grid, r, c - 1);
                if (c < grid.GetLength(1) - 1) DfsDistory(grid, r, c + 1);
            }
        }
    }
}
