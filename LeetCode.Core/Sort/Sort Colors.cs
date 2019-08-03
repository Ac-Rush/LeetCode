using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    public class Sort_Colors
    {
        public static void SortColors(int[] nums)
        {
            int second = nums.Length - 1, zero = 0;
            for (int i = 0; i <= second; i++)
            {
                while (nums[i] == 2 && i < second) Swap(nums, i, second--);
                while (nums[i] == 0 && i > zero) Swap(nums, i, zero++);
            }
        }

        /// <summary>
        /// 这个好理解
        /// </summary>
        /// <param name="nums"></param>
        public static void SortColors2(int[] nums)
        {
            int runner = 0, second = nums.Length - 1, zero = 0;
            while (runner <= second)
            {
                if (nums[runner] == 2) Swap(nums, runner, second--);   //这里的 run不++， 因为 second-- 这个数没有check过，需要再次loop
                else if (nums[runner] == 0) Swap(nums, zero++, runner++);
                else runner++;
            }
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
