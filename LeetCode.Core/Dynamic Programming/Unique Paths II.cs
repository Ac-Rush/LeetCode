using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Unique_Paths_II
    {
        /// <summary>
        /// my solution 一次过
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            var m = obstacleGrid.GetLength(0);
            var n = obstacleGrid.GetLength(1);
            var dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                if (obstacleGrid[i, 0] == 1)
                {
                    dp[i, 0] = 0;
                }else if (i == 0)
                {
                    dp[i, 0] = 1;
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 0];
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (obstacleGrid[0, i] == 1)
                {
                    dp[0, i] = 0;
                }
                else if (i == 0)
                {
                    dp[0, i] = 1;
                }
                else
                {
                    dp[0, i] = dp[0, i -1];
                }
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i, j] == 1)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }
            return dp[m - 1, n - 1];
        }


        public int UniquePathsWithObstacles2(int[,] obstacleGrid)
        {
            var m = obstacleGrid.GetLength(0);
            var n = obstacleGrid.GetLength(1);
            int[] dp = new int[n];
            dp[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (obstacleGrid[i, j] == 1)
                    {
                        dp[j] = 0;
                    }
                    else if (j > 0)
                    {
                        dp[j] += dp[j - 1];  // dp[j]  就是上一行的值。。。 如此变成一列的
                    }
                }
            }
           
            return dp[n - 1];
        }
    }
}
