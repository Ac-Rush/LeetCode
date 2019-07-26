using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Ugly_Number_II
    {
        /*
         
            We have an array k of first n ugly number. We only know, at the beginning, the first one, which is 1. Then

k[1] = min( k[0]x2, k[0]x3, k[0]x5). The answer is k[0]x2. So we move 2's pointer to 1. Then we test:

k[2] = min( k[1]x2, k[0]x3, k[0]x5). And so on. Be careful about the cases such as 6, in which we need to forward both pointers of 2 and 3.
    */
        int NthUglyNumber(int n)
        {
            if (n <= 0) return 0; // get rid of corner cases 
            if (n == 1) return 1; // base case
            int t2 = 0, t3 = 0, t5 = 0; //pointers for 2, 3, 5
            var k = new int [n];
            k[0] = 1;
            for (int i = 1; i < n; i++)
            {
                k[i] = Math.Min(k[t2] * 2, Math.Min(k[t3] * 3, k[t5] * 5));
                if (k[i] == k[t2] * 2) t2++;
                if (k[i] == k[t3] * 3) t3++;
                if (k[i] == k[t5] * 5) t5++;
            }
            return k[n - 1];
        }
    }
}
