using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{

    class Remove_Duplicates_from_Sorted_Array
    {
        /// <summary>
        /// good my solution 
        /// 
        /// two pointer 方法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            var pre = nums[0];
            var start = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != pre)
                {
                    pre = nums[i];
                    nums[start++] = pre;
                }
            }
            return start;
        }
    }

    class Remove_Duplicates_from_Sorted_Array_my
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            var pre = nums[0];
            var len = 1;
            var list = new List<int> { pre };
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != pre)
                {
                    len++;
                    pre = nums[i];
                    list.Add(pre);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                nums[i] = list[i];
            }
            //nums = list.ToArray();
            return len;
        }
    }
}
