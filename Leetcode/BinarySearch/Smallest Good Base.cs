using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Smallest_Good_Base
    {
        public string SmallestGoodBase(string nn)
        {
           /*
            long n = long.Parse(nn);
            long res = 0;
            for (int k = 60; k >= 2; k--)
            {
                long s = 2, e = n;
                while (s < e)
                {
                    long m = s + (e - s) / 2;

                    BigInteger left = new BigInteger(m);
                    left = BigInteger.Subtract(BigInteger.Pow(left,k),BigInteger.One);
                    BigInteger right = BigInteger.Multiply(new BigInteger(m),BigInteger.valueOf(m).subtract(BigInteger.ONE)), (BigInteger.valueOf(m).subtract(BigInteger.ONE)));
                    int cmr = left.compareTo(right);
                    if (cmr == 0)
                    {
                        res = m;
                        break;
                    }
                    else if (cmr < 0)
                    {
                        s = m + 1;
                    }
                    else
                    {
                        e = m;
                    }
                }

                if (res != 0) break;
            }

            return "" + res;
            */
           return null;
        }
    }
}
