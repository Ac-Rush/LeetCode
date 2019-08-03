using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Subsets_Class
    {
        static IList<IList<int>> result;
        /// <summary>
        /// https://leetcode.com/problems/subsets/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Subsets(int[] nums)
        {
            result = new List<IList<int>>();
            Helper(nums, 0 , new List<int>());
            return result;
        }

        public static void Helper(int[] nums, int index, IList<int> set)
        {
            if(index == nums.Length)
            {
                result.Add(new List<int>(set));
                return;
            }

            Helper(nums, index +1, set);
            set.Add(nums[index]);
            Helper(nums, index + 1, set);
            set.Remove(nums[index]);
        }
    }
}
