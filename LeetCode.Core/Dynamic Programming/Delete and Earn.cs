using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    public class Delete_and_Earn
    {
        /// <summary>
        /// 状态机
        /// avoid 不取 M 的最大值
        /// Use 取M   的最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int DeleteAndEarn(int[] nums)
        {
            int[] count = new int[10001];
            foreach (var x in nums)
            {
                count[x]++;
            }
            int avoid = 0, use = 0, prev = -1;

            for (int k = 0; k <= 10000; ++k)
                if (count[k] > 0)
                {
                    int m = Math.Max(avoid, use) ;
                    if (k - 1 != prev)
                    {
                        use = k * count[k] + m;
                        avoid = m;
                    }
                    else
                    {
                        use = k * count[k] + avoid;
                        avoid = m;
                    }
                    prev = k;
                }
            return Math.Max(avoid, use) ;
        }
    }
}
