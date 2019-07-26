using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    internal class Valid_Perfect_Square
    {
        /// <summary>
        /// my solution  居然用范围二分
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPerfectSquare(int num)
        {
            if (num < 2)
            {
                return true;
            }
            long start, mid, midsq, end;
            start = 1;
            end = num/2;
            while (start <= end)
            {
                 mid = start + (end - start)/2;
                midsq = mid*mid;
                if (midsq == num)
                {
                    return true;
                }else if (midsq < num)
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
