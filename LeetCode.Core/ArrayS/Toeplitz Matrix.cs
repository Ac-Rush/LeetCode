using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Toeplitz_Matrix
    {
        public bool IsToeplitzMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); ++r)
                for (int c = 0; c < matrix.GetLength(1); ++c)
                    if (r > 0 && c > 0 && matrix[r - 1,c - 1] != matrix[r,c])
                        return false;
            return true;
        }
    }
}
