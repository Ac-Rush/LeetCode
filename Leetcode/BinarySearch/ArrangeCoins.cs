using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class ArrangeCoins
    {
        public int arrangeCoins(int n)
        {
            int count = 1;
            while (n >= count)
            {
                n -= count++;
            }
            return count - 1;
        }

        public int ArrangeCoins2(int n)
        {
            return (int)((Math.Sqrt(1 + 8.0 * n) - 1) / 2);
        }
    }
}
