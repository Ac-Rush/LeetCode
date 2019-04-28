using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Smallest_Range_I
    {
        public int SmallestRangeI(int[] A, int K)
        {
            var min = A.Min();
            var max = A.Max();
            return max - min > K * 2 ? max - min - K - K : 0;
        }
    }
}
