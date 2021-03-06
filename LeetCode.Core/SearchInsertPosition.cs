﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class SearchInsertPosition
    {
        public static int SearchInsert(int[] nums, int target)
        {
            var l = 0; var r = nums.Length - 1;
            while (l < r)
            {
                var mid = l + (r - l) / 2;
                if(nums[mid] == target)
                {
                    return mid;
                }else if(nums[mid] < target)
                {
                    l = mid + 1;
                }else
                {
                    r = mid ;  // my bug was  r = mid - 1;  根据 mid的意义来判断， mid是第一个大于等于target的index. 最终就是返回 l;
                }
            }
            if(l == nums.Length - 1 && nums[l] < target)
            {
                return l + 1;
            }
            return l;

        }


        public static int SearchInsert2(int[] nums, int target)
        {
            var low = 0; var high = nums.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] > target) high = mid - 1;
                else low = mid + 1;
            }
            // (1) At this point, low > high. That is, low >= high+1
            // (2) From the invariant, we know that the index is between [low, high+1], so low <= high+1. Follwing from (1), now we know low == high+1.
            // (3) Following from (2), the index is between [low, high+1] = [low, low], which means that low is the desired index
            //     Therefore, we return low as the answer. You can also return high+1 as the result, since low == high+1
            return low;
        }


        private static int firstGreaterEqual(int[] A, int target)
        {
            int low = 0, high = A.Length;  //这个超赞high = A.Length 而不是 high = A.Length -1, 这是因为 low 不能等high， 所以不会越界， 这样可以找到第一个大的，如果不存在就返回 length.
            while (low < high)
            {
                int mid = low + ((high - low) >> 1);
                if (A[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    //should not be mid-1 when A[mid]==target.
                    //could be mid even if A[mid]>target because mid<high.
                    high = mid;
                }
            }
            return low;
        }

    }
}
