using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Number_of_Digit_One
    {
        public int CountDigitOne(int n)
        {
            long count = 0;

            for (long k = 1; k <= n; k *= 10)
            {
                long r = n / k, m = n % k;
                // sum up the count of ones on every place k
                count += (r + 8) / 10 * k + (r % 10 == 1 ? m + 1 : 0);
            }

            return (int)count;
        }
    }
}
