using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Number_of_1_Bits
    {
        public int HammingWeight(uint n)
        {
            var count = 0;
            while (n > 0)
            {
                n = n & (n - 1);  //删掉最右边的1；
                count++;
            }
            return count;
        }
    }
}
