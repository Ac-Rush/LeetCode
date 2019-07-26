using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    public class K_diff_Pairs_in_an_Array
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindPairs(int[] nums, int k)
        {
            System.Array.Sort(nums);
            var count = 0;
            for (int i = 0; i < nums.Length -1; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i +1; j < nums.Length; j++) //my bug j was i
                {
                    if (j != i +1 && nums[j] == nums[j - 1]) continue;
                    if (Math.Abs(nums[j] - nums[i]) == k)
                    {
                        count ++;
                    }
                    else if(Math.Abs(nums[j] - nums[i]) > k)
                    {
                        break;  //剪枝
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// two pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindPairs2(int[] nums, int k)
        {
            System.Array.Sort(nums);
            var ans = 0;
            for (int i = 0, j = 0; i < nums.Length -1; i++)
            {
                for (j = Math.Max(j, i + 1); j < nums.Length && (long)nums[j] - nums[i] < k; j++) ;
                if (j < nums.Length && (long)nums[j] - nums[i] == k) ans++;
                while (i + 1 < nums.Length && nums[i] == nums[i + 1]) i++;
            }
            return ans;
        }
    }
}
