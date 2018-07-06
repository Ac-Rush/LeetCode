using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Next_Greater_Element_II
    {
        /// <summary>
        /// stack  两杯数组的解法
        /// 这个也得看看
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] nextGreaterElements(int[] nums)
        {
            int[] res = new int[nums.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 2 * nums.Length - 1; i >= 0; --i)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i % nums.Length])
                {
                    stack.Pop();
                }
                res[i % nums.Length] = stack.Count ==0 ? -1 : nums[stack.Peek()];
                stack.Push(i % nums.Length);
            }
            return res;
        }

        /// <summary>
        /// 暴力解法  N^2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] nums)
        {
            int[] res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                res[i] = -1;
                for (int j = 1; j < nums.Length; j++)
                {
                    if (nums[(i + j) % nums.Length] > nums[i])
                    {
                        res[i] = nums[(i + j) % nums.Length];
                        break;
                    }
                }
            }
            return res;
        }
    }
}
