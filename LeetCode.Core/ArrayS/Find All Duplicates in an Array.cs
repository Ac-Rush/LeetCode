using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Find_All_Duplicates_in_an_Array
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    result.Add(Math.Abs(index + 1));
                nums[index] = -nums[index];
            }
            return result;
        }
    }
}
