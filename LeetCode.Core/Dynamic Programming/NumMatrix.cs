using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{

    class NumMatrix
    {
        private int[,] dp; //这就是多扩展一行一列的好处，省了很多if

        public NumMatrix(int[,] matrix)
        {
            var r = matrix.GetLength(0);
            var c = matrix.GetLength(1);
            dp = new int[r +1, c + 1];
            for (int i = 1; i < r +1; i++)
            {
                for (int j = 1; j < c +1; j++)
                {
                    dp[i, j] = matrix[i-1, j-1];
                    dp[i, j] += dp[i - 1, j];
                    dp[i, j] += dp[i, j - 1];
                    dp[i, j] -= dp[i - 1, j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return dp[row2 + 1,col2 + 1] - dp[row1,col2 + 1] - dp[row2 + 1,col1] + dp[row1,col1];
        }
    }


    class NumMatrix2
    {
        private int[,] dp;

        public NumMatrix2(int[,] matrix)
        {
            var r = matrix.GetLength(0);
            var c = matrix.GetLength(1);
            dp = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    dp[i, j] = matrix[i, j];
                    if (i > 0)
                    {
                        dp[i, j] += dp[i - 1, j];
                    }
                    if (j > 0)
                    {
                        dp[i, j] += dp[i, j-1];
                    }
                    if (i > 0 && j > 0)
                    {
                        dp[i, j] -=dp[i-1,j-1];
                    }
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var ret = dp[row2, col2];
            if (row1 > 0)
            {
                ret -= dp[row1 - 1, col2];
            }
            if (col1 > 0)
            {
                ret -= dp[row2, col1 - 1];
            }
            if (row1 > 0 && col1 > 0)
            {
                ret += dp[row1 - 1, col1 - 1];
            }
            return ret;
        }
    }
}
