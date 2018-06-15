using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class Subarray_Sum_Equals_K
    {
        public static int SubarraySum(int[] nums, int k)
        {
            var count = 0;
            var sum = 0;
            var dict = new Dictionary<int, int>(); //<sum,count>
            dict[0] = 1;  //my bug 初始化
            foreach (var num in nums)
            {
                sum += num;
                if (dict.ContainsKey(sum - k))
                {
                    count+= dict[sum - k];
                }
                if (!dict.ContainsKey(sum))
                {
                    dict[sum] = 0;
                }
                dict[sum] ++;
            }
            return count;
        }
    }
}
