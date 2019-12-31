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
        /// 单调栈的问题 单调递增栈
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int LargestRectangleArea2(int[] height)
        {
            /**
             * Do push all heights including 0 height.
i - 1 - s.peek() uses the starting index where height[s.peek() + 1] >= height[tp], 
            because the index on top of the stack right now is the first index left of tp with height smaller than tp's height.
             */
            int len = height.Length;
            var s = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i <= len; i++)  //在最后面补了一个 0 高度的方块
            {
                int h = (i == len ? 0 : height[i]);//在最后面补了一个 0 高度的方块
                if (s.Count == 0 || h >= height[s.Peek()])  //  用单调递增栈 来求下一个小
                {
                    s.Push(i);
                }
                else
                {
                    int tp = s.Pop();
                    // 这个一定要注意 是(s.Count==0 ? i : i - 1 - s.Peek())；
                    // 长度的计算  不是 i-tp, 因为 tp-1 不一定小于 tp,小于tp的是 stack的上一个
                    //这个里的 stack保存了一份 到i 递增的序列
                    maxArea = Math.Max(maxArea, height[tp] * (s.Count==0 ? i : i - 1 - s.Peek()));
                    i--;  //这个 i--可以 把嵌套 while 换成一层
                }
            }
            return maxArea;
        }

        /// <summary>
        /// 用了单调递增栈 ，同时求了 下一个小和上一个小
        /// 这才是模板， 不喜欢 还要操作 i的解法
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int LargestRectangleArea3(int[] height)
        {
            /**
             * Do push all heights including 0 height.
i - 1 - s.peek() uses the starting index where height[s.peek() + 1] >= height[tp], 
            because the index on top of the stack right now is the first index left of tp with height smaller than tp's height.
             */
            int len = height.Length;
            var s = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i <= len; i++)  //在最后面补了一个 0 高度的方块
            {
                int h = (i == len ? 0 : height[i]);//在最后面补了一个 0 高度的方块
                while (s.Any() && height[s.Peek()] > h) //单调递增，求下一个小
                {
                    int tp = s.Pop();
                    // 这个一定要注意 是(s.Count==0 ? i : i - 1 - s.Peek())；
                    // 长度的计算  不是 i-tp, 因为 tp-1 不一定小于 tp,小于tp的是 stack的上一个
                    //这个里的 stack保存了一份 到i 递增的序列
                    maxArea = Math.Max(maxArea, height[tp] * (s.Count == 0 ? i : i - 1 - s.Peek())); //s.Peek()是上一个小
                }
                s.Push(i);
            }
            return maxArea;
        }

        public int NextBig(int[] height)
        {
            /**
             * Do push all heights including 0 height.
i - 1 - s.peek() uses the starting index where height[s.peek() + 1] >= height[tp], 
            because the index on top of the stack right now is the first index left of tp with height smaller than tp's height.
             */
            int len = height.Length;
            var s = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i <= len; i++)  //在最后面补了一个 0 高度的方块
            {
                int h = (i == len ? 0 : height[i]);//在最后面补了一个 0 高度的方块
                while (s.Any() && height[s.Peek()] > h) //单调递增，求下一个小
                {
                    int tp = s.Pop();
                     //do something
                   // maxArea = Math.Max(maxArea, height[tp] * (s.Count == 0 ? i : i - 1 - s.Peek())); //s.Peek()是上一个小
                }
                s.Push(i); //入栈
            }
            return maxArea;
        }
    }
}
