using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class MySqrtC
    {
        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }
            int left = 1, right = x / 2;
            while (true)
            {
                int mid = left + (right - left) / 2;
                if (mid > x / mid)
                {
                    right = mid - 1;
                }
                else
                {
                    if (mid + 1 > x / (mid + 1))
                        return mid;
                    left = mid + 1;
                }
            }
        }
    }
}
