using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
   //dp 方法
    public class NumMatrix
    {


        private int[,] dp;

        public NumMatrix(int[,] matrix)
        {
            var r = matrix.GetLength(0);
            var c = matrix.GetLength(1);
            dp = new int[r + 1, c + 1];
            for (int i = 1; i < r + 1; i++)
            {
                for (int j = 1; j < c + 1; j++)
                {
                    dp[i, j] = matrix[i - 1, j - 1];
                    dp[i, j] += dp[i - 1, j];
                    dp[i, j] += dp[i, j - 1];
                    dp[i, j] -= dp[i - 1, j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            //求 i,j 的位置
            int iMin = Math.Min(row1, row2);
            int iMax = Math.Max(row1, row2);

            int jMin = Math.Min(col1, col2);
            int jMax = Math.Max(col1, col2);

            return dp[iMax + 1,jMax + 1] - dp[iMax + 1,jMin] - dp[iMin,jMax + 1] + dp[iMin,jMin];
        }
    }
}
