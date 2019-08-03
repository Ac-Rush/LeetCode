using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.TwoPointer
{
    class Container_With_Most_Water
    {
        public int MaxArea(int[] height)
        {
            var maxWater = 0;
            for (int l = 0, r = (height.Length - 1); l < r;)
            {
                var current = (r - l) * Math.Min(height[r], height[l]);
                if (current > maxWater)
                {
                    maxWater = current;
                }
                if (height[r] > height[l])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return maxWater;
        }
    }
}
