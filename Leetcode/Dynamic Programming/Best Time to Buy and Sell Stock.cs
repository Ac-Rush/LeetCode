using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
    /// </summary>
    class Best_Time_to_Buy_and_Sell_Stock
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            
            int minprice = int.MaxValue;
            int maxprofit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minprice)
                    minprice = prices[i];
                else if (prices[i] - minprice > maxprofit)
                    maxprofit = prices[i] - minprice;
            }
            return maxprofit;
        }
    }

    class Best_Time_to_Buy_and_Sell_Stock2
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {

            var min = int.MaxValue;
            var max = 0;
            foreach (var p in prices)
            {
                min = Math.Min(min, p);
                max = Math.Max(max, p - min);
            }
            return max;
        }
    }
}
