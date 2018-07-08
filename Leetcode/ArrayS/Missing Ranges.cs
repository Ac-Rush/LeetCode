using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
   public class Missing_Ranges
    {
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            long next = lower;
            var ans = new List<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                // not within the range yet
                if (nums[i] < next) continue;     //如果比下一个小 就 continue
                // continue to find the next one
                if (nums[i] == next)   //如果正好相等 就  next++
                {
                    next++;
                    continue;
                }
                // get the missing range string format
                ans.Add(getRange(next, nums[i] - 1));

                // now we need to find the next number
                next = (long)nums[i] + 1;  //用 long来处理 越界  my bug
            }
            if (next <= upper) ans.Add(getRange(next, upper));
            return ans;
        }
        String getRange(long n1, int n2)
        {
            return (n1 == n2) ? n1.ToString(): $"{n1}->{n2}";
        }
    }
}
