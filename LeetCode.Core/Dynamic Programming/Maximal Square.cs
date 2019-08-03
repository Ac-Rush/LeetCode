using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Maximal_Square
    {
        public int MaximalSquare(char[,] matrix)
        {
            var r = matrix.GetLength(0);
            var c = matrix.GetLength(1);
            var dp = new int[r + 1, c + 1];
            var max = 0;

            for (int i = 1; i <= r ; i++)
            {
                for (int j = 1; j <= c; j++)
                {
                    if (matrix[i - 1, j - 1] == '1' )
                    {
                        dp[i,j] = Math.Min(Math.Min(dp[i,j - 1], dp[i - 1,j]), dp[i - 1,j - 1]) + 1;
                        max = Math.Max(max, dp[i, j]);
                    }
                }
            }
            return max * max;
        }


        /// <summary>
        /// Approach #3 (Better Dynamic Programming) [Accepted]
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int maximalSquare2(char[,] matrix)
        {
            var r = matrix.GetLength(0);
            var c = matrix.GetLength(1);
            var dp = new int[ c + 1];
            var max = 0;

            for (int i = 1; i <= r; i++)
            {
                int prev = 0;
                for (int j = 1; j <= c; j++)
                {
                    int temp = dp[j];
                    if (matrix[i - 1, j - 1] == '1')
                    {
                        dp[j] = Math.Min(Math.Min(dp[j - 1], dp[j]), prev) + 1;
                        max = Math.Max(max, dp[j]);
                    }
                    else
                    {
                        dp[j] = 0;
                    }
                    prev = temp;
                }
            }
            return max * max;


            
        }
    }
}
