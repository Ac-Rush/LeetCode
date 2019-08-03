using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Range_Addition_II
    {
        public int MaxCount(int m, int n, int[,] ops)
        {
            for (int i = 0; i < ops.GetLength(0); i++) // my bug GetLength(0)不是 Length
            {
                
                m = Math.Min(m, ops[i,0]);
                n = Math.Min(n, ops[i,1]);
            }

            return m*n;
        }
    }
}
