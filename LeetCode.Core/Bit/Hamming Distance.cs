using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Hamming_Distance
    {
        public int HammingDistance(int x, int y)
        {
            x ^= y;

            int count = 0;
            int i = 32;
            while (i > 0)
            {
                if ((x & 1) == 1)
                {
                    count++;
                }
                x >>= 1;
                i--;
            }
            return count;
        }
    }
}
