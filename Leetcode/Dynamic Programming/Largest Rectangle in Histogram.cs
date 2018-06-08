using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Largest_Rectangle_in_Histogram
    {
        /// <summary>
        /// my bad solution
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            var max = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                var min = heights[i];
                for (int j = i; j >= 0; j--)
                {
                    min = Math.Min(min, heights[j]);
                    max = Math.Max(max, min*(i - j + 1));
                }
            }
            return max;
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/largest-rectangle-under-histogram/
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int LargestRectangleArea2(int[] height)
        {
            int len = height.Length;
            var s = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i <= len; i++)
            {
                int h = (i == len ? 0 : height[i]);
                if (s.Count == 0 || h >= height[s.Peek()])
                {
                    s.Push(i);
                }
                else
                {
                    int tp = s.Pop();
                    maxArea = Math.Max(maxArea, height[tp] * (s.Count==0 ? i : i - 1 - s.Peek()));
                    i--;
                }
            }
            return maxArea;
        }
    }
}
