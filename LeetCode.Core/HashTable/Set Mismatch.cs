using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Set_Mismatch
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            var dict = new int[nums.Length];
            foreach (var num in nums)
            {
                dict[num - 1]++;
            }
            var result = new int[2];
            for (int i = 0; i < dict.Length; i++)
            {
                if (dict[i] == 0 )
                {
                    result[1] = (i+1);
                }
                if (dict[i] == 2)
                {
                    result[0] = (i + 1);
                }
            }
            return result;
        }
    }
}
