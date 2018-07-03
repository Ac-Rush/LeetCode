using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class One1_bit_and_2_bit_Characters
    {
        public bool IsOneBitCharacter(int[] bits)
        {
            int i = 0;
            while (i < bits.Length - 1)
            {
                i += bits[i] + 1;
            }
            return i == bits.Length - 1;
        }

        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public bool isOneBitCharacter2(int[] bits)
        {
            int i = bits.Length - 2;
            while (i >= 0 && bits[i] > 0) i--;
            return (bits.Length - i) % 2 == 0;
        }
    }
}
