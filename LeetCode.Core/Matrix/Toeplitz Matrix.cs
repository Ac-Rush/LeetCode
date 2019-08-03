using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Toeplitz_Matrix
    {
        public bool IsToeplitzMatrix(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    if (matrix[i,j] != matrix[i + 1,j + 1]) return false;
                }
            }
            return true;
        }
    }
}
