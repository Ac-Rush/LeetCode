using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class NumMatrix_Mutable
    {
        private int[,] tree;
        private int[,] nums;
        int m;
        int n;

        public NumMatrix_Mutable(int[,] matrix)
        {
            m = matrix.GetLength(0);
            n = matrix.GetLength(1);
            tree = new int[m + 1, n+ 1];
            nums = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    Update(i, j, matrix[i,j]);
                }
            }

        }

        public void Update(int row, int col, int val)
        {
            if (m == 0 || n == 0) return;
            int delta = val - nums[row, col];
            nums[row,col] = val;
            for (int i = row + 1; i <= m; i += i & (-i))
            {
                for (int j = col + 1; j <= n; j += j & (-j))
                {
                    tree[i,j] += delta;
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (m == 0 || n == 0) return 0;
            return sum(row2 + 1, col2 + 1) + sum(row1, col1) - sum(row1, col2 + 1) - sum(row2 + 1, col1);
        }

        public int sum(int row, int col)
        {
            int sum = 0;
            for (int i = row; i > 0; i -= i & (-i))
            {
                for (int j = col; j > 0; j -= j & (-j))
                {
                    sum += tree[i,j];
                }
            }
            return sum;
        }
    }
}
