using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Dynamic_Programming;

namespace Leetcode.Matrix
{

    public class Spiral_Matrix_Template
    {
        /// <summary>
        ///模板， 每次变动都需要边界check
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static IList<int> SpiralOrder(int[,] matrix)
        {
            var ans = new List<int>();
            int top = 0, left = 0;
            int bottom = matrix.GetLength(0) - 1;
            int right = matrix.GetLength(1) - 1;
            while (left <= right && top <= bottom)
            {
                for (var i = left; i <= right ; i++)
                {
                    ans.Add(matrix[top, i]); // 添加第一行
                }
                if(left > right || top > bottom) break;   //break 很重要，在while里面， 如果改变了 while判断的值  应该再判断下
                top++; // top就需要下移一位
                for (int i = top; i <= bottom ; i++)
                {
                    ans.Add(matrix[i, right]); // 添加右边一列
                }
                right--; //右边加完了， 右边左移
                if (left > right || top > bottom) break;
                for (int i = right; i >= left ; i--)
                {
                    ans.Add(matrix[bottom, i]); //添加下面一行
                }
                bottom--;// 下边 都加完了， 下边上移
                if (left > right || top > bottom) break;
                for (int i = bottom; i >= top ; i--)
                {
                    ans.Add(matrix[i, left]); // 添加左边一列
                }
                left++; //左边都加完了， 左边右移
            }
            return ans;

        }
    }
    public class Spiral_Matrix
    {
        /// <summary>
        /// bug 太多
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static IList<int> SpiralOrder(int[,] matrix)
        {
            var ans = new List<int>();
            int top = 0, left = 0;
            int bottom = matrix.GetLength(0) - 1;
            int right = matrix.GetLength(1) - 1;
            while (left <= right && top <= bottom)
            {
                for(var i = left; i <= right  && left <= right && top <= bottom; i++)// my bug was  for(var i = left; i <= right  ; i++)  都需要判断边界
                {
                    ans.Add(matrix[top,i]); // 添加第一行
                }
                top++; // top就需要下移一位
                for (int i = top; i <= bottom && left <= right && top <= bottom; i++)
                {
                    ans.Add(matrix[i, right]); // 添加右边一列
                }
                right --; //右边加完了， 右边左移
                for (int i = right; i >= left && left <= right && top <= bottom; i--)
                {
                    ans.Add(matrix[bottom , i]); //添加下面一行
                }
                bottom--;// 下边 都加完了， 下边上移
                for (int i = bottom; i >= top && left <= right && top <= bottom; i--)
                {
                    ans.Add(matrix[i, left]); // 添加左边一列
                }
                left++; //左边都加完了， 左边右移
            }
            return ans;

        }
    }
}
