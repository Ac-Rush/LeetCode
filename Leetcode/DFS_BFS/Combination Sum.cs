using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Combination_Sum
    {
        IList<IList<int>> lists = new List<IList<int>>();
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var list = new List<int>();
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
                    if (candidates[i] <= target)
                    {
                        result.Add(candidates[i]);
                        Helper(candidates, i, target - candidates[i], result);
                        result.RemoveAt(result.Count - 1);
                    }
                }
            }
        }
    }
}
