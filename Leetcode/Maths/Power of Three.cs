using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Power_of_Three
    {
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0) return false; // my bug 没有check 边界
            return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;
        }

        public bool isPowerOfThree2(int n)
        {
            return n > 0 && 1162261467 % n == 0;
        }
    }
}
