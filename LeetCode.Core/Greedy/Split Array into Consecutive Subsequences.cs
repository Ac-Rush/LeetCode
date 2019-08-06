
using System;
using System.Collections;
using System.Collections.Generic;
namespace LeetCode.Core.Greedy
{
    class Split_Array_into_Consecutive_Subsequences
    {
        /// <summary>
        /// 贪心算法， 也可以用 PQ 求解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsPossible(int[] nums)
        {
            //let c1, c2, c3 be the number of consecutive subsequences ending at cur with length of 1
            int pre = int.MinValue, p1 = 0, p2 = 0, p3 = 0;
            int cur = 0, cnt = 0, c1 = 0, c2 = 0, c3 = 0;

            for (int i = 0; i < nums.Length; pre = cur, p1 = c1, p2 = c2, p3 = c3)
            {
                //第一步 计数
                for (cur = nums[i], cnt = 0; i < nums.Length && cur == nums[i]; cnt++, i++) ;

                if (cur != pre + 1)
                {
                    if (p1 != 0 || p2 != 0) return false;
                    c1 = cnt; c2 = 0; c3 = 0;

                }
                else
                {
                    if (cnt < p1 + p2) return false;
                    c1 = Math.Max(0, cnt - (p1 + p2 + p3));
                    c2 = p1;
                    c3 = p2 + Math.Min(p3, cnt - (p1 + p2));
                }
            }

            return (p1 == 0 && p2 == 0);
        }
    }
}
