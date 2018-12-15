using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Find_First_and_Last_Position_of_Element_in_Sorted_Array
    {
        public int[] SearchRange(int[] A, int target)
        {
            var n = A.Length;
            int i = 0, j = n - 1;
            var ret = new int[] {-1, -1};
            // Search for the left one
            while (i < j)
            {
                int mid = (i + j) / 2;
                if (A[mid] < target) i = mid + 1;
                else j = mid;
            }
            if (i >= n  ||A[i] != target) return ret;  //i >= n 判空 写到前面比较清晰
            else ret[0] = i;

            // Search for the right one
            j = n - 1;  // We don't have to set i to 0 the second time.
            while (i < j)
            {
                int mid = (i + j) / 2 + 1;  // Make mid biased to the right  //这个也很牛，可以避免 search range stuck.
                if (A[mid] > target) j = mid - 1;
                else i = mid;               // So that this won't make the search range stuck.
            }
            ret[1] = j;
            return ret;
        }

        private int FindFirst(int[] nums, int target)
        {
            var l = 0;
            var h = nums.Length - 1;
            while (l < h)
            {
                var mid = (h - l) / 2;
                if (nums[mid] < target)
                {
                    l = mid + 1;
                }
                else
                {
                    h = mid;
                }
            }
            return l;
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
