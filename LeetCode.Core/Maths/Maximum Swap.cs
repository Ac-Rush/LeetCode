using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-swap/
    /// </summary>
    class Maximum_Swap
    {
        public int MaximumSwap(int num)
        {
            char[] digits = num.ToString().ToArray();

            int[] buckets = new int[10];
            for (int i = 0; i < digits.Length; i++)
            {
                buckets[digits[i] - '0'] = i;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                for (int k = 9; k > digits[i] - '0'; k--)
                {
                    if (buckets[k] > i)
                    {
                        char tmp = digits[i];
                        digits[i] = digits[buckets[k]];
                        digits[buckets[k]] = tmp;
                        return int.Parse(new String(digits));
                    }
                }
            }

            return num;
        }
    }
}
