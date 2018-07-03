using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    /// <summary>
    /// /https://leetcode.com/problems/rotate-image/description/
    /// </summary>
    class Rotate_Image
    {
        public void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int tmp;
            for (int i = 0; i < Math.Ceiling((double)n / 2); i++)
            {
                for (int j = i; j < n - 1 - i; j++)
                {
                    tmp = matrix[i, j];
                    matrix[i, j] = matrix[n - 1 - j, i];
                    matrix[n - 1 - j, i] = matrix[n - 1 - i, n - 1 - j];
                    matrix[n - 1 - i, n - 1 - j] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = tmp;
                }
            }
        }

        public void Rotate2(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n / 2; i++)
            {
                RotateByLayer(matrix, i, n);
            }
        }

        private static void RotateByLayer(int[,] matrix, int layer, int n)
        {
            for (int j = layer; j < n - 1 - layer; j++)
            {
                var tmp = matrix[layer, j];
                matrix[layer, j] = matrix[n - 1 - j, layer];
                matrix[n - 1 - j, layer] = matrix[n - 1 - layer, n - 1 - j];
                matrix[n - 1 - layer, n - 1 - j] = matrix[j, n - 1 - layer];
                matrix[j, n - 1 - layer] = tmp;
            }
        }
    }
}
