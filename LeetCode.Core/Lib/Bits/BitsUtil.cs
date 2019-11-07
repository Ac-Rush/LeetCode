using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.Lib.Bits
{
    class BitsUtil
    {
        int Count_one(int n)
        {
            int count = 0;
            while (n!=0)
            {
                n = n & (n - 1);
                count++;
            }
            return count;
        }

        /// <summary>
        /// 非常有用， 用于上面的 count one
        /// <remarks>模板</remarks>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int Remove_last_bit(int n)
        {
            return n & (n - 1);
        }

        int Extract_last_bit(int n)
        {
            return n & -n;
        }


        int SetBit(int n, int k)
        {
            return n | 1 << k;
        }

        bool TestBit(int n, int k)
        {
            return (n & 1 << k) != 0;
        }


        /********不常用*****************************************************************************/

        /// <summary>
        /// 不常用
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int GetSum(int a, int b)
        {
            return b == 0 ? a : GetSum(a ^ b, (a & b) << 1); //be careful about the terminating condition;
        }

        bool isPowerOfFour(int num)
        {
            return num > 0 && (num & (num - 1)) == 0 && (num & 0x55555555) != 0;
            //check the 1-bit location;
        }
    }
}
