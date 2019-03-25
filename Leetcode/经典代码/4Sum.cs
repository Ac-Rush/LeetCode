using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class _4Sum
    {
        /// <summary>
        /// 错误答案
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            var dict = new Dictionary<int , List<int[]>>(); // <sun , [i ,j]>
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length -1; i++)
            {
                if(i!=0 && nums[i] == nums[i-1]) continue;  //排序 去重
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j != i+1 && nums[j] == nums[j - 1]) continue;  //去重
                    var sum = nums[i] + nums[j];
                    if (!dict.ContainsKey(sum))
                    {
                        dict[sum] = new List<int[]>();
                    }
                    dict[sum].Add(new []{i,j});
                }
            }
            var result = new HashSet<IList<int>>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1]) continue;  //排序 去重
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j != i + 1 && nums[j] == nums[j - 1]) continue;  //去重
                    int sum = nums[i] + nums[j];
                    if(!dict.ContainsKey(target - sum)) continue;
                    foreach (var list in dict[target - sum])
                    {
                        if (i == list[0] || i == list[1] || j == list[0] || j == list[1])
                        {
                            continue;
                        }
                        List<int> dummy = new List<int>() { nums[i] , nums[j], nums[list[0]] , nums[list[1]] };
                        dummy.Sort();
                        result.Add(dummy);
                    }
                   
                }
            }
            return result.ToList();
        }
    }


    public class _4Sum_3
    {
        public  IList<IList<int>> FourSum(int[] nums, int target)
        {
            System.Array.Sort(nums);
            return kSum(nums, 0, 4, target);
        }
        public IList<IList<int>> kSum(int[] nums, int start, int k, int target)
        {
            int len = nums.Length;
            IList<IList<int>> res = new List<IList<int>>();
            if (k == 2)
            {
                int left = start, right = len - 1;
                while (left < right)
                {
                    int sum = nums[left] + nums[right];
                    if (sum == target)
                    {
                        res.Add((new List<int> { nums[left], nums[right] }));
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < target) left++;
                    else right--;
                }
            }
            else
            {
                for (int i = start; i < len - k + 1; i++)
                {
                    while (i > start && i < len - 1 && nums[i] == nums[i - 1]) { i++; };
                    var temp = kSum(nums, i + 1, k - 1, target - nums[i]);
                    foreach (var element in temp)
                    {
                        element.Add(nums[i]);
                    }
                    foreach (var val in temp)
                    {
                        res.Add(val);
                    }
                }
            }

            return res;
        }
    }
}
