using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
   public   class Longest_Consecutive_Sequence
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LongestConsecutive(int[] nums)
        {
            var dict = new Dictionary<int, int[]>();  //int[0]  最左边的index, int[1]  最右边的index
            var max = 0;

            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    var arr = new int[2] { num, num };

                    if (dict.ContainsKey(num - 1))
                    {
                        arr[0] = dict[num - 1][0];
                    }
                    if (dict.ContainsKey(num + 1))
                    {
                        arr[1] = dict[num + 1][1];
                    }
                    dict[num] = arr;
                    dict[arr[0]][1] = arr[1];
                    dict[arr[1]][0] = arr[0];
                    max = Math.Max(max, arr[1] - arr[0] + 1);
                }
            }
            return max;
        }


        /// <summary>
        /// 这个没有我的好 最坏情况 不是 O（N）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int longestConsecutive(int[] nums)
        {
            var num_set = new HashSet<int>();
            foreach (int num in nums)
            {
                num_set.Add(num);
            }

            int longestStreak = 0;

            foreach (int num in num_set)
            {
                if (!num_set.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (num_set.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }
    }
}
