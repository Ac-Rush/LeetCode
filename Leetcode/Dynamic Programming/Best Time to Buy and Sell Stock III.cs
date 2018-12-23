using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Best_Time_to_Buy_and_Sell_Stock_III
    {
        public int MaxProfit(int[] prices)
        {
            int hold1 = int.MinValue, hold2 = int.MinValue;
            int release1 = 0, release2 = 0;
            foreach (var i in prices)
            {
                release2 = Math.Max(release2, hold2 + i);     // The maximum if we've just sold 2nd stock so far.
                hold2 = Math.Max(hold2, release1 - i);  // The maximum if we've just buy  2nd stock so far.
                release1 = Math.Max(release1, hold1 + i);     // The maximum if we've just sold 1nd stock so far.
                hold1 = Math.Max(hold1, -i);          // The maximum if we've just buy  1st stock so far. 
            }

            return release2; ///Since release1 is initiated as 0, so release2 will always higher than release1.
        }

        //k次的template， 上面的其实是一步一步推出来的
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/discuss/135704/Detail-explanation-of-DP-solution
        public int MaxProfitDpCompact2(int[] prices)
        {
            if (prices.Length == 0) return 0;
            var dp = new int[3];
            var min = new int[3];
           for(int i = 0; i < min.Length; i++)
            {
                min[i] = prices[0];
            }
            for (int i = 1; i < prices.Length; i++)
            {
                for (int k = 1; k <= 2; k++)
                {
                    min[k] = Math.Min(min[k], prices[i] - dp[k - 1]);
                    dp[k] = Math.Max(dp[k], prices[i] - min[k]);
                }
            }

            return dp[2];
        }


        /*
         * 两次情况下，这个好理解
         * 
         * 分析：动态规划法。以第i天为分界线，计算第i天之前进行一次交易的最大收益preProfit[i]，和第i天之后进行一次交易的最大收益postProfit[i]，
         * 最后遍历一遍，max{preProfit[i] + postProfit[i]} (0≤i≤n-1)就是最大收益。
         * 第i天之前和第i天之后进行一次的最大收益求法同Best Time to Buy and Sell Stock I。
         * 
         * 
         */

        public int MaxProfit2(int[] prices)
        {
            if (prices.Length < 2) return 0;

            int n = prices.Length;
            int[] preProfit = new int[n];
            int[] postProfit = new int[n];

            int curMin = prices[0];
            for (int i = 1; i < n; i++)
            {
                curMin = Math.Min(curMin, prices[i]);
                preProfit[i] = Math.Max(preProfit[i - 1], prices[i] - curMin);
            }

            int curMax = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                curMax = Math.Max(curMax, prices[i]);
                postProfit[i] = Math.Max(postProfit[i + 1], curMax - prices[i]);
            }

            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                maxProfit = Math.Max(maxProfit, preProfit[i] + postProfit[i]);
            }

            return maxProfit;
        }
    }
}
