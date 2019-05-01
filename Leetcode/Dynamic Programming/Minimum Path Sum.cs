using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Minimum_Path_Sum
    {

        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[,] grid)
        {
            var r = grid.GetLength(0);
            var c = grid.GetLength(1);
            var dp = new int[r, c ];
            for (int i = 0; i < r; i++)
            {
                
                for (int j = 0; j < c; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = grid[i, j];
                    }else if (i == 0)
                    {
                        dp[i, j] = grid[i, j] + dp[i, j - 1];
                    }else if (j == 0)
                    {
                        dp[i, j] = grid[i, j] + dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i, j];
                    }
                }
            }
            return dp[r - 1 , c - 1];
        }
    }


    class Minimum_Path_Sum2
    {

        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[,] grid)
        {
            var m = grid.GetLength(1);
            var n = grid.GetLength(0);
            var dp = new int[m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[j] = grid[i, j];
                    }
                    else if (i == 0)
                    {
                        dp[j] = grid[i, j] + dp[j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[j] = grid[i, j] + dp[j];
                    }
                    else
                    {
                        dp[j] = Math.Min(dp[j], dp[j - 1]) + grid[i, j];
                    }
                }
            }
            return dp[m - 1];
        }


        /// <summary>
        /// 二维规划+ 滚动数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum3(int[][] grid)
        {
            if (grid.Length == 0) return 0;
            int n = grid.Length, m = grid[0].Length;
            var dp = new int[m];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;//初始化成 int.max
            }
            for (int i = 0; i < n; i++)
            {
                dp[0] += grid[i][0];
                for (int j = 1; j < m; j++)
                {

                    dp[j] = Math.Min(dp[j], dp[j - 1]) + grid[i][j];
                }
            }
            return dp[m - 1];
        }
    }
}
