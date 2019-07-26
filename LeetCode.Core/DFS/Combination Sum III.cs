using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Combination_Sum_III
    {
        private IList<IList<int>> ans = new List<IList<int>>();
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            Dfs(new List<int>(), 1, k, n);
            return ans;
        }
        private void Dfs(List<int> cur, int index, int k, int n)
        {
            if (k == 0 && n == 0)
            {
                ans.Add(new List<int>(cur));
            }
            for (int i = index; i <= 9 && i <= n; i++)
            {
                cur.Add(i);
                Dfs(cur, i + 1, k - 1, n - i);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
