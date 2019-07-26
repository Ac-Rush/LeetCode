using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    class Find_K_th_Smallest_Pair_Distance
    {
        /*
         * 
         * 
         *   这个是 range binary search
      We will use a sliding window approach to count the number of pairs with distance <= guess.

For every possible right, we maintain the loop invariant: left is the smallest value such that
nums[right] - nums[left] <= guess. Then, the number of pairs with right as it's right-most endpoint is right - left, and we add all of these up.   
    */
        public int SmallestDistancePair(int[] nums, int k)
        {
            System.Array.Sort(nums);

            int lo = 0;
            int hi = nums[nums.Length - 1] - nums[0];  // 最大的差值，  
            while (lo < hi)
            {
                int mi = (lo + hi) / 2;
                int count = 0, left = 0;
                for (int right = 0; right < nums.Length; ++right)
                {
                    while (nums[right] - nums[left] > mi) left++;
                    count += right - left;
                }
                //count = number of pairs with distance <= mi
                if (count >= k) hi = mi;  // 找hi的定义，  hi 就是要 个数多余或是等于 k的 范围内
                else lo = mi + 1;   //而lo -1是 在相反的范围内
            }  //最终 lo会走到 这个范围的第一个值  （lo,..Hi0...Hi]  最终 lo会走到了 hi0 就是返回结果
            return lo;  
        }
    }
}
