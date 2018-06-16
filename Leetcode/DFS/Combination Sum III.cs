using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Combination_Sum_III
    {
        IList<IList<int>> lists = new List<IList<int>>();
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var candidates = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var list = new List<int>();
            System.Array.Sort(candidates);
            Helper(candidates, 0, n, list, k);
            return lists;
        }

        

        public void Helper(int[] candidates, int index, int target, List<int> result, int k)
        {
            if (target == 0  && result.Count ==k)
            {
                lists.Add(new List<int>(result));
            }
            if (result.Count >= k)
            {
                return;
            }
            if (target > 0)
            {
                for (int i = index; i < candidates.Length; i++)
                {
                    if (i > index && candidates[i] == candidates[i - 1])   //去重
                    {
                        continue;
                    }
                    if (candidates[i] <= target)
                    {
                        result.Add(candidates[i]);
                        Helper(candidates, i + 1, target - candidates[i], result,k);
                        result.RemoveAt(result.Count - 1);
                    }
                }
            }
        }
    }
}
