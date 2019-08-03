using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Smallest_Good_Base
    {
        /// <summary>
        /// 居然是个 binary search ， 我已经推导出来了 等比数列求和公式，没有想到 binarysearch.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string SmallestGoodBase(string n)
        {
            long num = long.Parse(n);

            for (int m = (int)(Math.Log(num + 1) / Math.Log(2)); m >= 2; m--)
            {
                long l = (long)(Math.Pow(num + 1, 1.0 / m));
                long r = (long)(Math.Pow(num, 1.0 / (m - 1)));

                while (l <= r)
                {
                    long k = l + ((r - l) >> 1);
                    long f = 0L;
                    for (int i = 0; i < m; i++, f = f * k + 1) ;

                    if (num == f)
                    {
                        return k.ToString();
                    }
                    else if (num < f)
                    {
                        r = k - 1;
                    }
                    else
                    {
                        l = k + 1;
                    }
                }
            }

            return (num - 1).ToString();
        }
    }
}
