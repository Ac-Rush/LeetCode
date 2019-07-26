using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Divide_Two_Integers
    {
        public int Divide(int dividend, int divisor)
        {
            //Reduce the problem to positive long integer to make it easier.
            //Use long to avoid integer overflow cases.
            int sign = 1;
            if ((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0))
                sign = -1;
            long ldividend = Math.Abs((long)dividend);
            long ldivisor = Math.Abs((long)divisor);

            //Take care the edge cases.
            if (ldivisor == 0) return Int32.MaxValue;
            if ((ldividend == 0) || (ldividend < ldivisor)) return 0;

            long lans = ldivide(ldividend, ldivisor);

            int ans;
            if (lans > Int32.MaxValue)
            { //Handle overflow.
                ans = (sign == 1) ? Int32.MaxValue : Int32.MinValue;
            }
            else
            {
                ans = (int)(sign * lans);
            }
            return ans;
        }

        private long ldivide(long ldividend, long ldivisor)
        {
            // Recursion exit condition
            if (ldividend < ldivisor) return 0;

            //  Find the largest multiple so that (divisor * multiple <= dividend), 
            //  whereas we are moving with stride 1, 2, 4, 8, 16...2^n for performance reason.
            //  Think this as a binary search.
            long sum = ldivisor;
            long multiple = 1;
            while ((sum + sum) <= ldividend)
            {
                sum += sum;
                multiple += multiple;
            }
            //Look for additional value for the multiple from the reminder (dividend - sum) recursively.
            return multiple + ldivide(ldividend - sum, ldivisor);
        }
    }
}
