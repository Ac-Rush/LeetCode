using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Magic_Squares_In_Grid
    {
        /// <summary>
        /// /Approach #1: Brute Force [Accepted]
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumMagicSquaresInside(int[][] grid)
        {
            int R = grid.Length, C = grid[0].Length;
            int ans = 0;
            for (int r = 0; r < R - 2; ++r)
                for (int c = 0; c < C - 2; ++c)
                {
                    if (magic(grid[r][c], grid[r][c + 1], grid[r][c + 2],
                              grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                              grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]))
                        ans++;
                }

            return ans;
        }

        public bool magic(params int[] vals)
        {
            int[] count = new int[16];
            foreach (int v in vals) count[v]++;
            for (int v = 1; v <= 9; ++v)
                if (count[v] != 1)
                    return false;

            return (vals[0] + vals[1] + vals[2] == 15 &&
                    vals[3] + vals[4] + vals[5] == 15 &&
                    vals[6] + vals[7] + vals[8] == 15 &&
                    vals[0] + vals[3] + vals[6] == 15 &&
                    vals[1] + vals[4] + vals[7] == 15 &&
                    vals[2] + vals[5] + vals[8] == 15 &&
                    vals[0] + vals[4] + vals[8] == 15 &&
                    vals[2] + vals[4] + vals[6] == 15);
        }
    }
}
