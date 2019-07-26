using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// N 的3次方时间复杂度
    /// </summary>
    class Cherry_Pickup_Memo
    {
        int[,,] memo;
        int[,] grid;
        int N;
        public int CherryPickup(int[,] grid)
        {
            this.grid = grid;
            N = grid.GetLength(0);
            memo = new int[N,N,N];
            for(int i = 0; i <N;i ++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        memo[i, j, k] = -1;
                    }
                }
            }
            return Math.Max(0, dp(0, 0, 0));
        }
        public int dp(int r1, int c1, int c2)
        {
            int r2 = r1 + c1 - c2; // r1+c1 = r2 + c2 // 所以r2可以推导出来，因为他们是同步走， 减少一维空间
            if (N == r1 || N == r2 || N == c1 || N == c2 ||
                    grid[r1,c1] == -1 || grid[r2,c2] == -1)
            {
                return -1;
            }
            else if (r1 == N - 1 && c1 == N - 1)
            {
                return grid[r1,c1];
            }
            else if (memo[r1,c1,c2] != -1)
            {
                return memo[r1,c1,c2];
            }
            else
            {
                int  ans = Math.Max(Math.Max(dp(r1, c1 + 1, c2 + 1), dp(r1 + 1, c1, c2 + 1)),
                                Math.Max(dp(r1, c1 + 1, c2), dp(r1 + 1, c1, c2)));
                if(ans < 0) { return memo[r1, c1, c2] = ans; }//给的答案是错的， 这里需要判断是不是所有分支都没有解，如果没有就是 -1
                ans += grid[r1, c1];
                if (c1 != c2) ans += grid[r2, c2];
                memo[r1,c1,c2] = ans;
                return ans;
            }
        }
    }


    class Cherry_Pickup_DP //这个答案不对， 可以用上面的 fix 来fix一下
    {
        public int CherryPickup(int[,] grid)
        {
            int N = grid.GetLength(0);
            int[,] dp = new int[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dp[i, j] = -1;
                }
            }
            dp[0,0] = grid[0,0];

            for (int t = 1; t <= 2 * N - 2; ++t)
            {
                int[,] dp2 = new int[N,N];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        dp2[i, j] = -1;
                    }
                }

                for (int i = Math.Max(0, t - (N - 1)); i <= Math.Min(N - 1, t); ++i)
                {
                    for (int j = Math.Max(0, t - (N - 1)); j <= Math.Min(N - 1, t); ++j)
                    {
                        if (grid[i,t - i] == -1 || grid[j,t - j] == -1) continue;
                        int val = grid[i,t - i];
                        if (i != j) val += grid[j,t - j];
                        for (int pi = i - 1; pi <= i; ++pi)
                            for (int pj = j - 1; pj <= j; ++pj)
                                if (pi >= 0 && pj >= 0)
                                    dp2[i,j] = Math.Max(dp2[i,j], dp[pi,pj] + val);
                    }
                }
                dp = dp2;
            }
            return Math.Max(0, dp[N - 1,N - 1]);
        }
    }
}
