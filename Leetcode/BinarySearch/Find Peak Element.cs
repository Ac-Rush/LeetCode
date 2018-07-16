using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Find_Peak_Element
    {
        public int FindPeakElement(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return i;
            }
            return nums.Length - 1;
        }


        public int findPeakElement2(int[] nums)
        {
            return search(nums, 0, nums.Length - 1);
        }
        public int search(int[] nums, int l, int r)
        {
            if (l == r)
                return l;
            int mid = (l + r) / 2;
            if (nums[mid] > nums[mid + 1])
                return search(nums, l, mid);
            return search(nums, mid + 1, r);
        }

        /// <summary>
        /// 其实可以从 第一个解 推导出来
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int findPeakElement3(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[mid + 1])  // r是 比右边大的  mid和右边的比较（这样不会越界）
                    r = mid;
                else
                    l = mid + 1;    //l 不比右边打
            }
            return l;
        }
    }
}
