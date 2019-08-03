using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Set_Matrix_Zeroes
    {
        public void SetZeroes(int[,] matrix)
        {
            //col0的意思是 第0 列是否有0    因为 第一行 和第一列的交界处 要特殊处理
            int col0 = 1, rows = matrix.GetLength(0), cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i,0] == 0) col0 = 0;
                for (int j = 1; j < cols; j++)
                    if (matrix[i,j] == 0)
                        matrix[i,0] = matrix[0,j] = 0;  //这个思路号， 只标记哨兵， 第一行 第一列
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = cols - 1; j >= 1; j--)
                    if (matrix[i,0] == 0 || matrix[0,j] == 0)
                        matrix[i,j] = 0;
                if (col0 == 0) matrix[i,0] = 0;
            }
        }
    }
}
