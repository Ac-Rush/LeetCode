using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Height_Checker
    {
        public int HeightChecker(int[] heights)
        {
            var ordered = heights.OrderBy(i=>i).ToArray();
            var count = 0;
            for(int i= 0;i < heights.Length; i++)
            {
                if(ordered[i] != heights[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
