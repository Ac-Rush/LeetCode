using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Power_of_Four
    {
        //太牛了
        public bool IsPowerOfFour(int num)
        {
            return num > 0 && (num & (num - 1)) == 0 && (num & 0x55555555) != 0;
            //0x55555555 is to get rid of those power of 2 but not power of 4
            //so that the single 1 bit always appears at the odd position 
        }
        public bool IsPowerOfTwo(int n)
        {

            if (n == 0) return false;
            return (n & (n - 1)) == 0;
        }
    }
}
