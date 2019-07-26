using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Coin_Change
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            for (int i = 1; i < amount + 1; i++)
            {
                dp[i] = int.MaxValue;
            }

            for (int i = 1; i < amount + 1; i++)
            {
                for (int j = 1; j < coins.Length + 1; j++)
                {
                    if (i - coins[j - 1] >= 0 && dp[i - coins[j - 1]]!= int.MaxValue)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j - 1]] + 1);
                    }
                }
            }
            return dp[amount] == int.MaxValue? -1 : dp[amount];
        }
    }
}
