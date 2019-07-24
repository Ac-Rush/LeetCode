using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Permutation
{
    class Permutations_II
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ret = new List<IList<int>>();
            System.Array.Sort(nums);
            Helper(ret, new List<int>(), nums, new bool[nums.Length]);
            return ret;
        }


        private void Helper(IList<IList<int>> ret, IList<int> cur, int[] nums, bool[] used)
        {
            if (cur.Count == nums.Length)
            {
                ret.Add(new List<int>(cur));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])) continue;  // 注意这个去重条件
                used[i] = true;
                cur.Add(nums[i]);
                Helper(ret, cur, nums, used);
                cur.RemoveAt(cur.Count - 1);
                used[i] = false;
            }
        }
    }
}
