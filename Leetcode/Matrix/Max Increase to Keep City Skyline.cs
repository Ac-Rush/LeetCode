using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Max_Increase_to_Keep_City_Skyline
    {
        /// <summary>
        ///  my solution
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            var left = new int[grid.Length];
            var top = new int[grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    left[i] = Math.Max(left[i], grid[i][j]);
                    top[j] = Math.Max(top[j], grid[i][j]);
                }
            }
            var count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    count += Math.Min(left[i], top[j]) - grid[i][j]; // my bug
                }
            }
            return count;
        }
    }
}
