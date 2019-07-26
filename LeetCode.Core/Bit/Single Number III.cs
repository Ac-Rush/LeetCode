using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Single_Number_III
    {
        /// <summary>
        /// 这个太棒了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SingleNumber(int[] nums)
        {
            // Pass 1 : 
            // Get the XOR of the two numbers we need to find
            int diff = 0;
            foreach (int num in nums)
            {
                diff ^= num;
            }
            // Get its last set bit
            //diff &= -diff;

            //  这个不对 明天研究下diff = diff - diff & (diff - 1);  居然需要小括号，注意优先级
            diff = diff - (diff & (diff - 1));
            // Pass 2 :
            int[] rets = { 0, 0 }; // this array stores the two numbers we will return
            foreach (int num in nums)
            {
                if ((num & diff) == 0) // the bit is not set
                {
                    rets[0] ^= num;
                }
                else // the bit is set
                {
                    rets[1] ^= num;
                }
            }
            return rets;
        }
    }
}
