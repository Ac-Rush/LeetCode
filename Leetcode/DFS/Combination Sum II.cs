using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Combination_Sum_II
    {
        private IList<IList<int>> ans = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            System.Array.Sort(candidates);
            Dfs(new List<int>(), 0, candidates, target);
            return ans;
        }
        private void Dfs(List<int> cur, int index, int[] candidates, int target)
        {
            if (target == 0)
            {
                ans.Add(new List<int>(cur));
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {
                if (i != index && candidates[i] == candidates[i - 1]) continue;
                if (target < candidates[i]) continue;
                cur.Add(candidates[i]);
                Dfs(cur, i + 1, candidates, target - candidates[i]);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }



    class Combination_Sum_II_2
    {
        IList<IList<int>> lists = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var list = new List<int>();
            System.Array.Sort(candidates);
            Helper(candidates, 0, target, list);
            return lists;
        }
        //另一种实现方法， 去重不如上一种好想
        public void Helper(int[] candidates, int index, int target, List<int> result)
        {
            if (target == 0)
            {
                lists.Add(new List<int>(result));
            }
            if (target > 0 && index < candidates.Length)
            {
                result.Add(candidates[index]);
                Helper(candidates, index + 1, target - candidates[index], result); //不可以重复用 ，i+1
                result.RemoveAt(result.Count - 1);

                index++;
                while (index < candidates.Length && candidates[index] == candidates[index - 1]) index++;
                Helper(candidates, index, target, result); //不可以重复用 ，i+1
            }
        }
    }
}
