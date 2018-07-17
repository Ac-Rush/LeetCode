﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class _01_Matrix
    {
        /// <summary>
        /// 从0 开始 泛洪遍历
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[,] UpdateMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j }); //从0  一起开始走
                    }
                    else
                    {
                        matrix[i,j] = int.MaxValue;
                    }
                }
            }

            int[,] dirs = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            while (queue.Any())
            {
                int[] cell = queue.Dequeue();
                for (int i = 0; i < dirs.GetLength(0); i++)
                {
                    int r = cell[0] + dirs[i,0];
                    int c = cell[1] + dirs[i, 1];
                    if (r < 0 || r >= m || c < 0 || c >= n ||
                        matrix[r,c] <= matrix[cell[0],cell[1]] + 1) continue;  //如果下个元素 小于等于 当前元素 +1 那么 剪枝
                    queue.Enqueue(new int[] { r, c });
                    matrix[r,c] = matrix[cell[0],cell[1]] + 1;
                }
            }

            return matrix;
        }
    }
}
