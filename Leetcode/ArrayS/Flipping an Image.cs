using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    public class Flipping_Image_832
    {
        public static int[][] FlipAndInvertImage(int[][] A)
        {
            var m = A.Length;
          //  var m = A.GetLength(1);
            var ret = new int[m][];
            for (var i = 0; i < m; i++)
            {
                int n = A[i].Length;
                ret[i] = new int[n];
                for (var j = 0; j < n; j++)
                {
                    ret[i][j] = A[i][n - 1 - j] == 0 ? 1 : 0;
                }
            }
            return ret;
        }

        public int[][] flipAndInvertImage2(int[][] A)
        {
            int C = A[0].Length;
            foreach (var row in A)
            {
                for (int i = 0; i < (C + 1) / 2; ++i)
                {
                    int tmp = row[i] ^ 1;
                    row[i] = row[C - 1 - i] ^ 1;
                    row[C - 1 - i] = tmp;
                }
            }
            return A;
        }
    }
}
