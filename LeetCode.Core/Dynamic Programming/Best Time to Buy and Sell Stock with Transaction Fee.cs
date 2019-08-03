using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/description/
    /// </summary>
    class Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee
    {
        public int MaxProfit(int[] prices, int fee)
        {
            // cash: 手头的现金，即总的赚的金额，同时也是未持股时的现金额
            // hold: 手中有持股时的现金，即总金额减去手中股票的买入价
            int cash = 0, hold = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                // 如果卖出持股比未持股赚，则卖出
                cash = Math.Max(cash, hold + prices[i] - fee);
                // hold 其实代表买入的最低价
                hold = Math.Max(hold, cash - prices[i]);
            }
            return cash;
        }

        public int MaxProfit2(int[] prices, int fee)
        {
            int s0 = 0, s1 = int.MinValue;
            foreach (var price in prices)
            {
                int tmp = s0;
                s0 = Math.Max(s0, s1 + price);
                s1 = Math.Max(s1, tmp - price - fee);
            }
            return s0;
        }
    }
}
