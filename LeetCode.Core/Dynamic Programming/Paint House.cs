using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Paint_House
    {
        /// <summary>
        /// 我的答案 几乎一次过， 用minColors[] 来保存当前house的现状
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[,] costs)
        {
            var minColors = new int[3];
            if (costs.GetLength(0) == 0) return 0;
            for (int i = 0; i < 3; i++)
            {
                minColors[i] = costs[0, i];
            }
            if (costs.GetLength(0) == 1) return minColors.Min();
            for (int i = 1; i < costs.GetLength(0); i++) // my bug  was i=2
            {
                var cur = new int[3];
                cur[0] = costs[i, 0] + Math.Min(minColors[1], minColors[2]);
                cur[1] = costs[i, 1] + Math.Min(minColors[0], minColors[2]);
                cur[2] = costs[i, 2] + Math.Min(minColors[1], minColors[0]);
                minColors = cur;
            }
            return minColors.Min();
        }
    }

    public class Paint_House_Scoll
    {
        /// <summary>
        /// 滚动数组， 节省空间
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[,] costs)
        {
            var minColors = new int[2,3];
            if (costs.GetLength(0) == 0) return 0;
            for (int i = 0; i < 3; i++)
            {
                minColors[0,i] = costs[0, i];
            }
            for (int i = 1; i < costs.GetLength(0); i++) // my bug  was i=2
            {
                minColors[i%2, 0] = costs[i, 0] + Math.Min(minColors[(i -1) % 2, 1], minColors[(i - 1) % 2, 2]);
                minColors[i % 2, 1] = costs[i, 1] + Math.Min(minColors[(i - 1) % 2, 0], minColors[(i - 1) % 2, 2]);
                minColors[i % 2, 2] = costs[i, 2] + Math.Min(minColors[(i - 1) % 2, 1], minColors[(i - 1) % 2, 0]);
            }
            var min = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                min = Math.Min(min, minColors[(costs.GetLength(0) - 1)%2, i]);
            }
            return min;
        }
    }
}
