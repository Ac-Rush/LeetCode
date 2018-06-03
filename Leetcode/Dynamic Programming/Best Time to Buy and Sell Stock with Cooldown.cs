using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
    {
        /*
         * 
         * Let b2, b1, b0 represent buy[i - 2], buy[i - 1], buy[i]
            Let s2, s1, s0 represent sell[i - 2], sell[i - 1], sell[i]

            b0 = Math.max(b1, s2 - prices[i]);
s0 = Math.max(s1, b1 + prices[i]);
         * 
         */
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            int b0 = -prices[0], b1 = b0;
            int s0 = 0, s1 = 0, s2 = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                b0 = Math.Max(b1, s2 - prices[i]);
                s0 = Math.Max(s1, b1 + prices[i]);
                b1 = b0; s2 = s1; s1 = s0;
            }
            return s0;
        }



        /*
         * 1. profit1[i+1] means I must sell on day i+1, and there are 2 cases:

a. If I just sold on day i, then I have to buy again on day i and sell on day i+1

b. If I did nothing on day i, then I have to buy today and sell today 

Taking both cases into account, profit1[i+1] = max(profit1[i]+prices[i+1]-prices[i], profit2[i])

2. profit2[i+1] means I do nothing on day i+1, so it will be max(profit1[i], profit2[i])
         * 
         */
        public int MaxProfit2(int[] prices)
        {
            int profit1 = 0, profit2 = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int copy = profit1;
                profit1 = Math.Max(profit1 + prices[i] - prices[i - 1], profit2);
                profit2 = Math.Max(copy, profit2);
            }
            return Math.Max(profit1, profit2);
        }
    }
}
