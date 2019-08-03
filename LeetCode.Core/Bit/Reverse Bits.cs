using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Reverse_Bits
    {
        public uint reverseBits(uint n)
        {
            uint num = 0;
            for (int i = 0; i < 32; ++i)
            {
                num <<= 1;
                num += n % 2;
                n >>= 1;
            }
            return num;
        }
    }
}
