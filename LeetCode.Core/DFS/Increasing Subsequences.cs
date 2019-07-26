using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Increasing_Subsequences
    {
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            var result = new List<IList<int>>();
            Dfs(result,nums,0, new List<int>());
            return result;
        }

        public void Dfs(List<IList<int>> result, int[] nums, int index, List<int> temp)
        {
            if ( temp.Count > 1)  // my bug  was if (index >= nums.Length && temp.Count > 1) 
            {
                result.Add(new List<int>(temp));
            }
            var used = new HashSet<int>();
            for (int i = index; i < nums.Length; i++)
            {
                if (used.Contains(nums[i])) continue; // skip duplicated
                if (temp.Count == 0 || temp.Last() <= nums[i])
                {
                    // Dfs(result, nums, i + 1, temp);
                    used.Add(nums[i]);
                    temp.Add(nums[i]);
                    Dfs(result, nums, i + 1, temp);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }


    }
}
