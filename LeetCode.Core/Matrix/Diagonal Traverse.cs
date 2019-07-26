using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Diagonal_Traverse
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] FindDiagonalOrder(int[,] matrix)
        {
           
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var sum = n + m - 2;
            var ret = new int[m*n];
             var dir = true;
            var index = 0;
            for (int k = 0; k <= sum; k++)
            {
                if (dir)
                {
                    for (int i = k; i >= 0; i--)
                    {
                        if (i < m && (k - i) >= 0 && (k - i) < n)
                        {
                            ret[index++] = matrix[i, k - i];
                        }
                    }
                    dir = !dir;
                }
                else
                {
                    for (int i = 0; i <= k; i++)
                    {
                        if (i < m && (k - i) >= 0 && (k - i) < n)
                        {
                            ret[index++] = matrix[i, k - i];
                        }
                    }
                    dir = !dir;
                }
            }
            return ret;
        }
    }


    class Diagonal_Traverse_2
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] FindDiagonalOrder(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return new int[0];
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var result = new int[m * n];
            int row = 0, col = 0, d = 0;
            int[,] dirs = { { -1, 1 }, { 1, -1 } };
            for (int i = 0; i < m * n; i++)
            {
                result[i] = matrix[row,col];
                row += dirs[d,0];
                col += dirs[d,1];

                if (row >= m) { row = m - 1; col += 2; d = 1 - d; }  //这个很巧妙
                if (col >= n) { col = n - 1; row += 2; d = 1 - d; }  //d 是方向
                if (row < 0) { row = 0; d = 1 - d; }
                if (col < 0) { col = 0; d = 1 - d; }
            }

            return result;
        }
    }
}
