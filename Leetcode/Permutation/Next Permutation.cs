using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Permutation
{
    class Next_Permutation
    {
        /// <summary>
     ///   /// 太牛了，
     ///  1. 从最右边找到第一个 降序的   i
     /// 2. 从上个index，向右找到最后一个比这个大的   j
     /// 3. 交换 i,j
     /// 4翻转 i+1后边的书， 升序最小
     /// </summary>
     /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            var n = nums.Length;
            int i = n - 2;
            while (i >=0 && nums[i] >= nums[i+1]) //my bug 第一个小的， 等于也不行，要注意一下
            {
                i--;
            }
            if (i < 0)
            {
                // reverse(nums, 0);
                System.Array.Reverse(nums);
                //            nums =   nums.Reverse().ToArray();   // 这个做法不对 翻转不了
                return;
            }
                 ;

            int j = n - 1;
            while (j >= 0 && nums[j] <= nums[i])
            {
                j--;
            }
            swap(nums, i, j); //3.交换 i,j
            reverse(nums, i + 1);  //4翻转 i+1后边的书， 升序最小
        }

        private void reverse(int[] a, int start)
        {
            int i = start, j = a.Length - 1;
            while (i < j)
            {
                swap(a, i, j);
                i++;
                j--;
            }
        }
        private void swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
