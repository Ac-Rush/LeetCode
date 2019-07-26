using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Paint_Fence
    {
        /*
         We divided it into two cases.

the last two posts have the same color, the number of ways to paint in this case is sameColorCounts.

the last two posts have different colors, and the number of ways in this case is diffColorCounts. 
         
         */
        public int NumWays(int n, int k)
        {
            if (n == 0) return 0;
            else if (n == 1) return k;
            int diffColorCounts = k * (k - 1);  // 前两个颜色不同
            int sameColorCounts = k;    //前两个颜色相同
            for (int i = 2; i < n; i++)
            {
               
                
                int temp = diffColorCounts;
                //如果当前用个不同色的 , 那么就是 之前同色 和不同色的和 *（k-1）
                diffColorCounts = (diffColorCounts + sameColorCounts) * (k - 1);
                //如果当前用同色的 ， 那么就是之前不同色的count
                sameColorCounts = temp;
            }
            return diffColorCounts + sameColorCounts;
        }
    }
}
