using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class Search_a_2D_Matrix
    {
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);
            if (matrix[0,0] > target || matrix[row - 1,col - 1] < target) return false;
            var start = 0;
            var end = row - 1;
            int mid;
            while (start +1 < end)
            {
                 mid = start + (end - start)/2;
                if (matrix[mid, 0] == target)
                {
                    return true;
                }
                if (matrix[mid, 0] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid;
                }
            }

            

            int curRow = start;
            if (target >= matrix[start, 0])
            {
                curRow = start;
            }
            if (target >= matrix[end, 0])
            {
                curRow = end;
            }

            start = 0;
            end = col - 1;
            while (start <= end)
            {
                 mid = start + (end - start) / 2;
                if (matrix[curRow, mid] == target)
                {
                    return true;
                }
                if (matrix[curRow, mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid +1;
                }
            }
            return false;
        }


        public static bool SearchMatrix2(int[,] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            int l = 0, r = m * n - 1;
            while (l != r)
            {
                int mid = (l + r - 1) >> 1;
                if (matrix[mid / m,mid % m] < target)
                    l = mid + 1;
                else
                    r = mid;
            }
            return matrix[r / m,r % m] == target;
        }
    }
}
