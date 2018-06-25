using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Factorial_Trailing_Zeroes
    {
        public int TrailingZeroes(int n)
        {
            return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
        }
    }
}
