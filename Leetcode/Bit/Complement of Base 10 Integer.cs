using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Complement_of_Base_10_Integer
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int BitwiseComplement(int N)
        {
            if (N == 0) return 1;
            int ans = 0, rate = 1;

            while(N > 0)
            {
                ans +=  (1-N%2 ) * rate;
                N /= 2;
                rate *= 2;
            }
            return ans;
        }

        /// <summary>
        /// 不懂，不如我的好
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int BitwiseComplement2(int N)
        {
            int X = 1;
            while (N > X) X = X * 2 + 1;
            return X - N;
        }
    }
}
