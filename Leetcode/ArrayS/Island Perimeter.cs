using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class Island_Perimeter
    {
        public static int IslandPerimeter(int[,] grid)
        {
            var sum = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                    {
                        sum += 4;
                        if (i - 1 >= 0 && grid[i - 1, j] == 1)
                        {
                            sum -= 2;
                        }
                        if (j - 1 >= 0 && grid[i, j - 1] == 1)
                        {
                            sum -= 2;
                        }
                    }
                }
            }
            return sum;
        }
    }
}
