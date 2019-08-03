using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class NumMatrix_Mutable
    {
        private int[,] tree;   //叫做树状数组Binary Indexed Tree 的值
        private int[,] nums;  //matrix的值
        int m;
        int n;

        public NumMatrix_Mutable(int[,] matrix)
        {
            m = matrix.GetLength(0);
            n = matrix.GetLength(1);
            tree = new int[m + 1, n+ 1]; //从 1,1开始  否则0没法算
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
            for (int i = row + 1; i <= m; i += i & (-i))//和一维的一样， 每次都加最低为    //从 r+1,c+1开始  否则0没法算
            {
                for (int j = col + 1; j <= n; j += j & (-j))  //和一维的一样， 每次都加最低为 //从 1,1开始  否则0没法算
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
            for (int i = row; i > 0; i -= i & (-i))//和一维的一样， 每次都减最低为
            {
                for (int j = col; j > 0; j -= j & (-j)) //和一维的一样， 每次都减最低为
                {
                    sum += tree[i,j];
                }
            }
            return sum;
        }
    }
}
