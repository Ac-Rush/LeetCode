using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Delete_Columns_to_Make_Sorted
    {
        public int MinDeletionSize(string[] A)
        {
            int del = 0;
            for (int col = 0; col < A[0].Length; col++)
            {
                for (int row = 0; row < A.Length - 1; row++)
                {
                    if (A[row][col] > A[row + 1][col])
                    {
                        del++;
                        break;
                    }
                }
            }
            return del;
        }
    }
}
