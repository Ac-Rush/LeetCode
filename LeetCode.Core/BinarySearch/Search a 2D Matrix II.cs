using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Search_a_2D_Matrix_II
    {
        /// <summary>
        /// 这个简单
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);
            if (matrix[0, 0] > target || matrix[row - 1, col - 1] < target) return false;

            //从左下角 往右上走， 
            int col_index = 0;  
            var row_index = row - 1;
            while (row_index >= 0 && col_index < col)
            {
                if (matrix[row_index, col_index] == target)
                {
                    return true;  //等于 退出
                }
                if (matrix[row_index, col_index] > target)
                {
                    row_index--;  //如果大了，往上走
                }
                else
                {
                    col_index++;  //如果小了， 往右走
                }
            }
            return false;
        }
    }
}
