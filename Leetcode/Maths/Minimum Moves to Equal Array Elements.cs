using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Minimum_Moves_to_Equal_Array_Elements
    {
        /// <summary>
        /// 都变成最大 或最小 或 ave是一样的
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMoves(int[] nums)
        {
            int moves = 0, min = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                moves += nums[i];
                min = Math.Min(min, nums[i]);
            }
            return moves - min * nums.Length;
        }
    }
}
