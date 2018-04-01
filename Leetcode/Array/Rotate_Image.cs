﻿using System;
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
    }
}
