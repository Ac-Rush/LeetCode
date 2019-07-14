using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class _477__Total_Hamming_Distance
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TotalHammingDistance(int[] nums)
        {
            int total = 0, n = nums.Length;
            for (int j = 0; j < 32; j++)
            {
                int bitCount = 0;
                for (int i = 0; i < n; i++)
                    bitCount += (nums[i] >> j) & 1;
                //巧妙地计算不同的数量
                total += bitCount * (n - bitCount);
            }
            return total;
        }
    }
}
