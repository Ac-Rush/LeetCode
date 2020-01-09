using System.Collections.Generic;

namespace Leetcode.ArrayS
{
    class _3Sum
    {

        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            var ans = new List<IList<int>>();
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                int l = i + 1, h = nums.Length - 1;
                while (l < h)
                {
                    var sum = nums[i] + nums[l] + nums[h];
                    if (sum == 0)
                    {
                        ans.Add(new List<int>() { nums[i], nums[l], nums[h] });
                        while (l < h && nums[l] == nums[l + 1]) l++;
                        while (l < h && nums[h] == nums[h - 1]) h--;
                        l++; h--;
                    }
                    else if (sum > 0)h--;
                    else l++;
                }
            }
            return ans;
        }

        /// <summary>
        /// 先排序， 去重，选定一个数， 然后 i+1, length-1 之间 twopointer 并且去重
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i != 0 && (i <= 0 || nums[i] == nums[i - 1])) // remove duplication  //去重很重要 如何去重 
                {
                    continue;
                }
                int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
                while (lo < hi)
                {
                    if (nums[lo] + nums[hi] == sum)
                    {
                        result.Add(new List<int>() { nums[i], nums[lo], nums[hi] });
                        while (lo < hi && nums[lo] == nums[lo + 1]) lo++; // remove duplication   //去重很重要 如何去重 
                        while (lo < hi && nums[hi] == nums[hi - 1]) hi--; // remove duplication   //去重很重要 如何去重 
                        lo++; hi--;
                    }
                    else if (nums[lo] + nums[hi] < sum) lo++;
                    else hi--;
                }
            }
            return result;
        }
    }
}
