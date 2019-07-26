using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    

    class Super_Pow
    {
        //One knowledge: ab % k = (a%k)(b%k)%k
        public int SuperPow(int a, int[] b)
        {
            if (a % 1337 == 0) return 0;
            int p = 0;
            foreach (int i in b) p = (p * 10 + i) % 1140;
            if (p == 0) p += 1440;
            return power(a, p, 1337);
        }
        public int power(int a, int n, int mod)
        {
            a %= mod;
            int ret = 1;
            while (n != 0)
            {
                if ((n & 1) != 0) ret = ret * a % mod;
                a = a * a % mod;
                n >>= 1;
            }
            return ret;
        }
    }
}
