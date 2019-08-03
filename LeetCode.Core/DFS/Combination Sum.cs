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
                        Helper(candidates, i, target - candidates[i], result);  //这里 i 不++ 因为可以重复用
                        result.RemoveAt(result.Count - 1);
                    }
                }
            }
        }
    }

    class Combination_Sum2
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            DFS(result, new List<int>(), candidates, target, 0);
            return result;
        }

        private void DFS(IList<IList<int>> result, List<int> current, int[] candidates, int target, int index)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }
            if (index >= candidates.Length || target < 0) return;

            DFS(result, current, candidates, target, index + 1);
            current.Add(candidates[index]);
            DFS(result, current, candidates, target - candidates[index], index);
            current.RemoveAt(current.Count - 1);
        }
    }
}
