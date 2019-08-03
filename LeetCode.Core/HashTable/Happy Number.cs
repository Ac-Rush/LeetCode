using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Happy_Number
    {
        public bool IsHappy(int n)
        {
            var inLoop = new HashSet<int>();
            int squareSum, remain;
            while (inLoop.Add(n))
            {
                squareSum = 0;
                while (n > 0)
                {
                    remain = n % 10;
                    squareSum += remain * remain;
                    n /= 10;
                }
                if (squareSum == 1)
                    return true;
                else
                    n = squareSum;

            }
            return false;
        }
    }
}
