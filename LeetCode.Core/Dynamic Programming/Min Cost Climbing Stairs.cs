using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// https://leetcode.com/problems/min-cost-climbing-stairs/description/
    /// </summary>
    class Min_Cost_Climbing_Stairs
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length < 2)
            {
                return 0;
            }
            var first = cost[0];
            var second = cost[1];
            for (int i = 2; i < cost.Length; i++)
            {
                var temp = cost[i] + Math.Min(first, second);
                first = second;
                second = temp;
            }
            return Math.Min(first, second);
        }
    }
}
