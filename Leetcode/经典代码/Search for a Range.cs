using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    /// <summary>
    /// https://leetcode.com/problems/search-for-a-range/description/
    /// </summary>
    class Search_for_a_RangeC
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int[] targetRange = { -1, -1 };

            int leftIdx = ExtremeInsertionIndex(nums, target, true);

            // assert that `leftIdx` is within the array bounds and that `target`
            // is actually in `nums`.
            if (leftIdx == nums.Length || nums[leftIdx] != target)
            {
                return targetRange;
            }

            targetRange[0] = leftIdx;
            targetRange[1] = ExtremeInsertionIndex(nums, target, false) - 1;

            return targetRange;
        }

        // returns leftmost (or rightmost) index at which `target` should be
        // inserted in sorted array `nums` via binary search.
        /*
         * 定义好了 hi， 让 lo =mid +1 逼近， 最终相交就是要找的位置
         */
        private int ExtremeInsertionIndex(int[] nums, int target, bool left)
        {
            int lo = 0;
            int hi = nums.Length;

            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] > target || (left && target == nums[mid]))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return lo;
        }
    }


    class Search_for_a_Range2C
    {
        public int[] SearchRange(int[] A, int target)
        {
            int start = firstGreaterEqual(A, target);
            if (start == A.Length || A[start] != target)
            {
                return new int[] { -1, -1 };
            }
            return new int[] { start, firstGreaterEqual(A, target + 1) - 1 };
        }


        //find the first number that is greater than or equal to target.
        //could return A.length if target is greater than A[A.length-1].
        //actually this is the same as lower_bound in C++ STL.
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

        /// <summary>
        /// find first 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int findFirst(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }

        private int findLast(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] <= target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }
    }
}
