using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    /// <summary>
    /// https://leetcode.com/problems/max-area-of-island/description/
    /// </summary>
    public class Max_Area_of_Island
    {
        
        public int MaxAreaOfIsland(int[,] grid)
        {
            int max_area = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i,j] == 1) max_area = Math.Max(max_area, AreaOfIsland(grid, i, j));
            return max_area;
        }

        public int AreaOfIsland(int[,] grid, int i, int j)
        {
            if (i >= 0 && i < grid.GetLength(0) && j >= 0 && j < grid.GetLength(1) && grid[i,j] == 1)
            {
                grid[i,j] = 0;
                return 1 + AreaOfIsland(grid, i + 1, j) + AreaOfIsland(grid, i - 1, j) + AreaOfIsland(grid, i, j - 1) + AreaOfIsland(grid, i, j + 1);
            }
            return 0;
        }

    }
}
