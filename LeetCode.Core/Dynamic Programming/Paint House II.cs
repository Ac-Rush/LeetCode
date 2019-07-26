using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Paint_House_II
    {
        /// <summary>
        /// 我的答案 几乎一次过， 用minColors[] 来保存当前house的现状
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[,] costs)
        {
            if (costs.GetLength(0) == 0) return 0;
            var c = costs.GetLength(1);
            var minColors = new int[c];
            for (int i = 0; i < c; i++)
            {
                minColors[i] = costs[0, i];
            }
            for (int i = 1; i < costs.GetLength(0); i++) // my bug  was i=2
            {
                var cur = new int[c];
                for (int j = 0; j < c; j++)
                {
                    cur[j] = int.MaxValue;  //my bug 这个需要初始化一下
                    for (int k = 0; k < c; k++)
                    {
                        if(k== j) continue;
                        cur[j] = Math.Min(cur[j], costs[i, j] + minColors[k]);
                    }
                }
                minColors = cur;
            }
            return minColors.Min();
        }
    }


    class Paint_House_II_2
    {
        /// <summary>
        ///  这个好 ， 记录 最小和第二小即可
        /// 时间复杂度 O(NK)
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[,] costs)
        {
            if (costs.GetLength(0) == 0) return 0;
            int n = costs.GetLength(0);
            var k = costs.GetLength(1);
            // min1 is the index of the 1st-smallest cost till previous house
            // min2 is the index of the 2nd-smallest cost till previous house
            int min1 = -1, min2 = -1;
            for (int i = 0; i < n; i++)
            {
                int last1 = min1, last2 = min2;
                min1 = -1; min2 = -1;

                for (int j = 0; j < k; j++)
                {
                    if (j != last1)
                    {
                        // current color j is different to last min1
                        costs[i,j] += last1 < 0 ? 0 : costs[i - 1,last1];
                    }
                    else
                    {
                        costs[i,j] += last2 < 0 ? 0 : costs[i - 1,last2];
                    }

                    // find the indices of 1st and 2nd smallest cost of painting current house i
                    if (min1 < 0 || costs[i,j] < costs[i,min1])
                    {
                        min2 = min1; min1 = j;
                    }
                    else if (min2 < 0 || costs[i,j] < costs[i,min2])
                    {
                        min2 = j;
                    }
                }
            }

            return costs[n - 1,min1];
        }
    }
}
