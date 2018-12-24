using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Arithmetic_Slices_II___Subsequence
    {
        public int NumberOfArithmeticSlices(int[] A)
        {
            int res = 0;
            var map = new Dictionary<int,int>[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                map[i] = new Dictionary<int, int>();

                for (int j = 0; j < i; j++)
                {
                    long diff = (long) A[i] - A[j];
                    if (diff <= int.MinValue || diff > int.MaxValue) continue; // 这个是越界检查

                    int d = (int) diff;
                    int c1 = map[i].ContainsKey(d) ? map[i][d] : 0;
                    int c2 = map[j].ContainsKey(d) ? map[j][d] : 0;
                    res += c2;
                    map[i][d] = c1 + c2 + 1;
                }
            }

            return res;
        }
    }
}
