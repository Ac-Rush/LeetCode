using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    // 推荐 Stack的解法 

    /// <summary>
    /// DP 问题 维护三个 数组  left/right/Height
    /// left , 从最上层到目前层， 第i 列 从左到右第一个 1的位置
    ///  rigth , 从最上层到目前层， 第i 列 从右到左第一个 1的位置
    /// </summary>
    public class Maximal_Rectangle
    {
        /*
  我们可以把left[j]这个函数加深理解为， 从过往所有行到当前行， 在 j 这个位置，遇到的最晚的一个1在哪里， 
  那么当前left就应该更新到哪里。 因为left函数记录了过往所有行的左边界情况，所以，考虑左边界的时候不仅仅要考虑当前行的情况，还要根据过往所有行的情况(保存在left[j]里)， 选择里面最大的一个（也就是最靠后的一个作为左边界）。 因为如果之前的左边界比现在的小，由于当前行左边界更靠后，那么在计算面积的时候也不能按照之前的左边界计算，只能按照当前左边界计算。如下图：


               */


        /*
         left: 左边界的定义： 从0到该j位置， 第一个1的位置。
         left[j] = max(总体左边界, left[j]) 
         right: 右边界的定义： 从j 到该行末尾，第一个1的位置 
         Height： 从上到下的高度
            left(i,j) = max(left(i-1,j), cur_left), cur_left can be determined from the current row

right(i,j) = min(right(i-1,j), cur_right), cur_right can be determined from the current row

height(i,j) = height(i-1,j) + 1, if matrix[i][j]=='1';

height(i,j) = 0, if matrix[i][j]=='0'
    */
        public static  int MaximalRectangle(char[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            if (m == 0 && n == 0) return 0;
            int[] left = new int[n], right = new int[n], height = new int[n];
            for (int i = 0; i < n; i++)
            {
                right[i] = n;
            }
            var maxA = 0;
            for (var i = 0; i < m; i++)
            {
                int cur_left = 0, cur_right = n;
                for (var j = 0; j < n; j++)  //更新高度数组
                {
                    // compute height (can do this from either side)
                    if (matrix[i, j] == '1') height[j]++;
                    else height[j] = 0;
                }
                for (var j = 0; j < n; j++) //更新 left 数组
                {
                    // compute left (from left to right)
                    if (matrix[i, j] == '1') left[j] = Math.Max(left[j], cur_left);
                    else
                    {
                        left[j] = 0;
                        cur_left = j + 1;
                    }
                }
                // compute right (from right to left)
                for (var j = n - 1; j >= 0; j--)//更新 right 数组
                {
                    if (matrix[i, j] == '1') right[j] = Math.Min(right[j], cur_right);
                    else
                    {
                        right[j] = n;
                        cur_right = j;
                    }
                }
                // compute the area of rectangle (can do this from either side)
                for (var j = 0; j < n; j++)
                    maxA = Math.Max(maxA, (right[j] - left[j])*height[j]);
            }
            return maxA;
        }
    }

    /// <summary>
    /// Largest_Rectangle_in_Histogram
    /// 保存 height 数组 用 Largest_Rectangle_in_Histogram来求解每一行
    /// </summary>
    public class Maximal_Rectangle_Stack
    {
        //O （N^2） 的时间复杂度
        public int MaximalRectangle(char[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            if (m == 0 && n == 0) return 0;
            int[] height = new int[n];
            var maxA = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    // compute height (can do this from either side)
                    if (matrix[i, j] == '1') height[j]++;
                    else height[j] = 0;
                }
                
                // compute the area of rectangle (can do this from either side)
                var curtMax = LargestRectangleArea(height);
                maxA = Math.Max(maxA, curtMax);
            }
            return maxA;
        }

       //O （N） 的时间复杂度
        public int LargestRectangleArea(int[] height)
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
                    maxArea = Math.Max(maxArea, height[tp] * (s.Count == 0 ? i : i - 1 - s.Peek()));
                    i--;
                }
            }
            return maxArea;
        }
    }
}
