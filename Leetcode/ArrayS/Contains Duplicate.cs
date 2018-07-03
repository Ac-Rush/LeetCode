using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Contains_Duplicate
    {
        /// <summary>
        /// O（n^2）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool containsDuplicate(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (nums[j] == nums[i]) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// O（NlogN）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool containsDuplicate2(int[] nums)
        {
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }

        /// <summary>
        /// HashSet O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool containsDuplicate3(int[] nums)
        {
            var set = new HashSet<int>();
            foreach (int x in nums)
            {
                if (set.Contains(x)) return true;
                set.Add(x);
            }
            return false;
        }
    }
}
