using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Search_in_Rotated_Sorted_Array
    {
        /// <summary>
        /// 画图比划一下就行了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int l = 0, h = nums.Length - 1;
            while (l <= h)
            {
                var mid = (l + h) / 2;
                if (nums[mid] == target) return mid;

                if (nums[mid] > nums[h])  // 如果中间的 大于high,
                {
                    if (target >= nums[l] && target < nums[mid]) // 那么  [l...mid] 这段有序 ， 思想就是 挑出我们可以解决的小问题（二分查找）
                    {
                        h = mid - 1;
                    } 
                    else  // 如果上面不符合 那么下面就是递归的解法
                    {
                        l = mid + 1;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[h]) // <= 那么 [mid....h] 这段有序
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        h = mid - 1;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// too many 问题
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search2(int[] nums, int target)
        {


            var l = 0;
            var h = nums.Length - 1;
            while (l <= h)
            {
                var mid = l + (h - l) / 2;
                if (nums[mid] == target) return mid;
                if (nums[l] <= nums[mid])  //一定分好条件  mid 可能等于 l ， 而 mid 不会等于h
                {
                    if (nums[mid] > target && nums[l] <= target)
                    {
                        h = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && nums[h] >= target)  //注意 《=
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        h = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}
