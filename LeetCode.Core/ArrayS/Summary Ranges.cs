using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Summary_Ranges_My2
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<string> SummaryRanges(int[] nums)
        {
            var ans = new List<string>();
            for (int i,j = 0; j < nums.Length; j++)
            {
                i = j;
                // try to extend the range [nums[i], nums[j]]
                while (j + 1 < nums.Length && nums[j + 1] == nums[j] + 1)
                    ++j;
                // put the range into the list
                if (i == j)
                    ans.Add(nums[i] + "");
                else
                    ans.Add(nums[i] + "->" + nums[j]);
            }
           
            return ans;
        }
    }

    class Summary_Ranges_My
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<string> SummaryRanges(int[] nums)
        {
            var ans = new List<string>();
            if (nums.Length == 0) return ans;
            var start = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1] + 1)
                {
                    if (start == nums[i - 1])
                    {
                        ans.Add(start.ToString());
                    }
                    else
                    {
                        ans.Add($"{start}->{nums[i - 1]}");
                    }
                    start = nums[i];
                }
            }
            if (start == nums[nums.Length - 1])
            {
                ans.Add(start.ToString());
            }
            else
            {
                ans.Add($"{start}->{nums[nums.Length - 1]}");
            }
            return ans;
        }
    }
}
