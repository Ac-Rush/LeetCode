﻿using System;
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
                    if (target >= nums[l] && target < nums[mid]) //
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
                    if (target > nums[mid] && target <= nums[h])
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
