using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class House_Robber_II
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            return Math.Max(nums[0] + Rob(nums, 2, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
        }

        public int Rob(int[] nums, int start, int end)
        {
            int rob = 0, preRob = 0;
            for (int i = start; i <= end; i++)
            {
                var temp = rob;
                rob = Math.Max(rob, preRob + nums[i]);
                preRob = temp;
            }
            return rob;
        }
    }
}
