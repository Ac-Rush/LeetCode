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


        public int[][] GenerateMatrix2(int n)
        {
            var ans = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ans[i] = new int[n];
            }

            int l = 0, r = n - 1, top = 0, bottom = n - 1, num = 1;
            while (l <= r && top <= bottom)
            {
                for (int i = l; i <= r; i++) ans[top][i] = num++;
                top++;
                for (int i = top; i <= bottom && l <= r && top <= bottom; i++) ans[i][r] = num++;
                r--;
                for (int i = r; i >= l && l <= r && top <= bottom; i--) ans[bottom][i] = num++;
                bottom--;
                for (int i = bottom; i >= top && l <= r && top <= bottom; i--) ans[i][l] = num++;
                l++;
            }
            return ans;
        }
    }
}
