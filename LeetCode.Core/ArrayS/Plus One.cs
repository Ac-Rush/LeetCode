using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Plus_One
    {
        /// <summary>
        ///  mu solution
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            var newOne = new int[digits.Length + 1];
            newOne[0] = 1;
            return newOne;
        }

        /// <summary>
        /// 我的解法真烂
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            int rest = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var sum = rest + digits[i];
                digits[i] = sum % 10;
                rest = sum / 10;
            }
            if (rest == 1)
            {
                digits = new int[digits.Length + 1];
                digits[0] = 1;
            }
            return digits;
        }

    }
}
