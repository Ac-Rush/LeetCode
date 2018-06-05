using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Combination_Sum_II
    {
        IList<IList<int>> lists = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var list = new List<int>();
            System.Array.Sort(candidates);
            Helper(candidates, 0, target, list);
            return lists;
        }

        public void Helper(int[] candidates, int index, int target, List<int> result)
        {
            if (target == 0)
            {
                lists.Add(new List<int>(result));
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
                        Helper(candidates, i + 1, target - candidates[i], result);
                        result.RemoveAt(result.Count - 1);
                    }
                }
            }
        }
    }
}
