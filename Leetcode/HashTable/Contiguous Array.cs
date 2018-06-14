using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Contiguous_Array
    {
        /// <summary>
        /// 统计出 count hash
        ///  </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxLength(int[] nums)
        {
            var map = new Dictionary<int,int>();
            map[0] = -1; // 上一次为0 的index
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 1 ? 1 : -1);
                if (map.ContainsKey(count))
                {
                    maxlen = Math.Max(maxlen, i - map[count]);
                }
                else
                {
                    map[count]= i;
                }
            }
            return maxlen;
        }

        public int findMaxLength2(int[] nums)
        {
            int[] arr = new int[2 * nums.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -2;
            }
            arr[nums.Length] = -1;
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 0 ? -1 : 1);
                if (arr[count + nums.Length] >= -1)
                {
                    maxlen = Math.Max(maxlen, i - arr[count + nums.Length]);
                }
                else
                {
                    arr[count + nums.Length] = i;
                }

            }
            return maxlen;
        }


        /// <summary>
        /// /Approach #1 Brute Force [Time Limit Exceeded]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int findMaxLength(int[] nums)
        {
            int maxlen = 0;
            for (int start = 0; start < nums.Length; start++)
            {
                int zeroes = 0, ones = 0;
                for (int end = start; end < nums.Length; end++)
                {
                    if (nums[end] == 0)
                    {
                        zeroes++;
                    }
                    else
                    {
                        ones++;
                    }
                    if (zeroes == ones)
                    {
                        maxlen = Math.Max(maxlen, end - start + 1);
                    }
                }
            }
            return maxlen;
        }
    }
}
