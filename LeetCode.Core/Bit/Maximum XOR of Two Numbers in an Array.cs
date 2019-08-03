using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Maximum_XOR_of_Two_Numbers_in_an_Array
    {
        /// <summary>
        /// my solution  O（N^2）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            var max = 0;
            for (int i = 0; i < nums.Length -1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    max = Math.Max(max, nums[i] ^ nums[j]);
                }
            }
            return max;
        }
    }


    class Maximum_XOR_of_Two_Numbers_in_an_Array_O_N
    {
        /// <summary>
        /// my solution  O（N^2）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            int max = 0, mask = 0;
            for (int i = 31; i >= 0; i--)
            {
                mask = mask | (1 << i);
                var set = new HashSet<int>();
                foreach (int num in nums)
                {
                    set.Add(num & mask);
                }
                int tmp = max | (1 << i);
                foreach (int prefix in set)
                {
                    if (set.Contains(tmp ^ prefix))
                    {
                        max = tmp;
                        break;
                    }
                }
            }
            return max;
        }
    }
}
