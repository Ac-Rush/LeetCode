using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Permutation
{
    class Combinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var ret = new List<IList<int>>();
            Dfs(ret, new List<int>(), 1, n, k);
            return ret;
        }

        private void Dfs(IList<IList<int>> result, IList<int> cur, int s, int n, int k)
        {
            if (cur.Count == k)
            {
                result.Add(new List<int>(cur));
                return;
            }
            for (int i = s; i <= n; i++)
            {
                cur.Add(i);
                Dfs(result, cur, i + 1, n, k);
                cur.RemoveAt(cur.Count - 1);
            }

        }
    }
}
