using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Remove_Duplicates_from_Sorted_Array_II
    {
        /// <summary>
        /// 居然如此简单，  真是 大神
        ///
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            foreach (int n in nums)
                //如果 i 是前两个数，
                //或者 这个数大于，前面的倒是第二个数
            //那么就挪动赋值
                if (i < 2 || n > nums[i - 2])
                    nums[i++] = n;
            return i;
        }
    }
}
