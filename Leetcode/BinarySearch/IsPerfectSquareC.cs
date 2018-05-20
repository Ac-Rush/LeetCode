using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class IsPerfectSquareC
    {
        public bool IsPerfectSquare(int num)
        {
            if (num == 0)
            {
                return true;
            }
            var sqart = (int)Math.Sqrt(num);
            return sqart * sqart == num ? true : false;
        }

        public bool IsPerfectSquare2(int num)
        {
            if (num < 2)
                return true;
            long start, mid, midsq, end;
            start = 1;
            end = num / 2;
            while (start <= end)
            {
                mid = (start + end) / 2;
                midsq = mid * mid;
                if (midsq == num)
                {
                    return true;
                }
                else if (midsq < num)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return false;
        }
    }
}
