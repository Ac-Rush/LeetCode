using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Longest_Line_of_Consecutive_One_in_Matrix
    {
        //用最后一维度来保存 4中 state
        public int LongestLine(int[,] M)
        {
            var m = M.GetLength(0);
            var n = M.GetLength(1);
            var max = 0;
            var dp = new int[m,n,4]; //这样表示就好了
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (M[i,j] == 0) continue;
                    for (int k = 0; k < 4; k++) dp[i,j,k] = 1;
                    if (j > 0) dp[i,j,0] += dp[i,j - 1,0]; // horizontal line
                    if (j > 0 && i > 0) dp[i,j,1] += dp[i - 1,j - 1,1]; // anti-diagonal line
                    if (i > 0) dp[i,j,2] += dp[i - 1,j,2]; // vertical line
                    if (j < m - 1 && i > 0) dp[i,j,3] += dp[i - 1,j + 1,3]; // diagonal line
                    max = Math.Max(max, Math.Max(dp[i,j,0], dp[i,j,1]));
                    max = Math.Max(max, Math.Max(dp[i,j,2], dp[i,j,3]));
                }
            }
            return max;
        }
    }
}
