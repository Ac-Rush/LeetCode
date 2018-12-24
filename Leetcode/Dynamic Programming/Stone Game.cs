using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Stone_Game
    {
        public bool StoneGame(int[] p)
        {
            int n = p.Length;
            int[,] dp = new int[n,n];
            for (int i = 0; i < n; i++) dp[i,i] = p[i];
            for (int d = 1; d < n; d++)
                for (int i = 0; i < n - d; i++)
                    dp[i,i + d] = Math.Max(p[i] - dp[i + 1,i + d], p[i + d] - dp[i,i + d - 1]);
            return dp[0,n - 1] > 0;
        }
    }
}
