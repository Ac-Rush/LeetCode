using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.SlidingWindow
{
    class Longest_Repeating_Character_Replacement
    {
        /// <summary>
        /// 居然是个sliding window的题目
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CharacterReplacement(string s, int k)
        {
            int len = s.Length;
            int[] count = new int[26];
            int start = 0, maxCount = 0, maxLength = 0;
            for (int end = 0; end < len; end++)
            {
                maxCount = Math.Max(maxCount, ++count[s[end] - 'A']);
                while (end - start + 1 - maxCount > k) // validate ; 总长度 end-start+1, 减去队尾的元素个数 ， 去调整头
                {
                    count[s[start] - 'A']--;
                    start++;
                }
                maxLength = Math.Max(maxLength, end - start + 1);
            }
            return maxLength;
        }
    }
}
