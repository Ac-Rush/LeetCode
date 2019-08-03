using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Counting_Bits
    {
        /*
         * f(0) =  0;
         * f(1) =  f(0) + 1;
         * f(2) = f(2/1)  + 0;
         * f(3) == f(11) = f(1) + 1;
         * f(4) =  f(10) = f(1) +0;
         * 
         * 
         */
        public int[] CountBits(int num)
        {
            int[] f = new int[num + 1];
            for (int i = 1; i <= num; i++) f[i] = f[i >> 1] + (i & 1);
            return f;
        }

        
    }
}
