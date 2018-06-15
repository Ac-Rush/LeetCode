using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class _4Sum
    {
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            var dict = new Dictionary<int , List<int[]>>(); // <sun , [i ,j]>
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length -1; i++)
            {
                if(i!=0 && nums[i] == nums[i-1]) continue;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j != i+1 && nums[j] == nums[j - 1]) continue;
                    var sum = nums[i] + nums[j];
                    if (!dict.ContainsKey(sum))
                    {
                        dict[sum] = new List<int[]>();
                    }
                    dict[sum].Add(new []{i,j});
                }
            }
            var result = new List<IList<int>>();
            foreach (var key in dict.Keys)
            {
                if (dict.ContainsKey(target - key) && key >=(target - key))
                {
                    var firstTwo = dict[key];
                    var otherTwo = dict[target - key];
                    foreach (var two in firstTwo)
                    {
                        foreach (var other in otherTwo)
                        {
                            if (two[0] != other[0] && two[0] != other[1]
                            && two[1] != other[0] && two[1] != other[1])
                            {
                                var ans = new List<int> {nums[two[0]], nums[two[1]], nums[other[0]], nums[other[0]]};
                                result.Add(ans);
                            }
                        }
                        
                    }
                }
            }
            return result;
        }
    }
}
