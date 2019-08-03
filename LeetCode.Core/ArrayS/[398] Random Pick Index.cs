using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    public class Solution
    {

        int[] nums;
        Random rnd;

        public Solution(int[] nums)
        {
            this.nums = nums;
            this.rnd = new Random();
        }

        public int Pick(int target)
        {
            int result = -1;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != target)
                    continue;
                if (rnd.Next(++count) == 0)
                    result = i;
            }

            return result;
        }
    }
}
