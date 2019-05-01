using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Pow_x__n_
    {
        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            if (n < 0)
            {
                //overflow happen
                n = -n;
                x = 1 / x;
            }
            return (n % 2 == 0) ? MyPow(x * x, n / 2) : x * MyPow(x * x, n / 2);
        }

        public double MyPow3(double x, int n)
        {
            if (n == 0)
                return 1;

            if (n < 0)
            {
                x = 1 / x;
                if (n == int.MinValue)
                    return x * MyPow3(x, int.MaxValue);
                else
                    n = -n;
            }
            return n % 2 == 0 ? MyPow3(x * x, n / 2) : x * MyPow3(x, n - 1);
        }

        public double MyPow2(double x, int n)
        {
            double temp = x;
            if (n == 0)
                return 1;
            temp = MyPow2(x, n / 2);
            if (n  % 2 == 0)
                return temp * temp;
            else
            {
                if (n > 0)
                    return x * temp * temp;  // 区别正负幂
                else
                    return (temp * temp) / x;
            }
        }

    }
}
