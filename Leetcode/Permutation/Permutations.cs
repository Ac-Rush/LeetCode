using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Permutation
{
    class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var ret = new List<IList<int>>();
            Helper(ret, new List<int>(), nums, new HashSet<int>());
            return ret;
        }

        private void Helper(IList<IList<int>> ret, IList<int> cur, int[] nums, HashSet<int> set)
        {
            if (cur.Count == nums.Length)
            {
                ret.Add(new List<int>(cur));
                return;
            }
            foreach (var n in nums)
            {
                if (set.Contains(n)) continue;
                set.Add(n);
                cur.Add(n);
                Helper(ret, cur, nums, set);
                cur.RemoveAt(cur.Count - 1);
                set.Remove(n);
            }
        }
    }

    class Permutations2
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var ret = new List<IList<int>>();
            Helper(ret, new List<int>(), nums, new HashSet<int>());
            return ret;
        }

        private void Helper(IList<IList<int>> ret, IList<int> cur, int[] nums, HashSet<int> set)
        {
            if (cur.Count == nums.Length)
            {
                ret.Add(new List<int>(cur));
                return;
            }
            foreach (var n in nums)
            {
                if (set.Contains(n)) continue;
                set.Add(n);
                cur.Add(n);
                Helper(ret, cur, nums, set);
                cur.RemoveAt(cur.Count - 1);
                set.Remove(n);
            }
        }
    }
}
