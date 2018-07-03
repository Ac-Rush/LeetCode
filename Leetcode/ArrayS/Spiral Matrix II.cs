using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Spiral_Matrix_II
    {
        public int[,] GenerateMatrix(int n)
        {
            var len = n;
            var ret = new int[len, len];
            int left = 0, top = 0;
            int right = n - 1, down = n - 1;
            int count = 1;
            while (left <= right)
            {
                for (int j = left; j <= right; j++)
                {
                    ret[top,j] = count++;
                }
                top++;
                for (int i = top; i <= down; i++)
                {
                    ret[i,right] = count++;
                }
                right--;
                for (int j = right; j >= left; j--)
                {
                    ret[down,j] = count++;
                }
                down--;
                for (int i = down; i >= top; i--)
                {
                    ret[i,left] = count++;
                }
                left++;
            }
            return ret;
        }
    }
}
