using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Power_of_Two
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0) return false; // my bug 没有check 边界
            return (n&(n - 1)) == 0;
        }
    }
}
