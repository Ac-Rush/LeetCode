using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.TwoPointer
{
    public class Longest_Substring_with_At_Most_K_Distinct_Characters
    {
        /// <summary>
        ///  my solution
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            var left = 0;
            var right = 0;
            var set = new Dictionary<char,int>();
            var max = 0;
            while (right < s.Length)
            {
                if (!set.ContainsKey(s[right]))
                {
                    set[s[right]] = 0;
                }
                set[s[right++]]++;
                if (set.Count <= k)
                {
                    max = Math.Max(max, right - left);
                }
                while (set.Count > k)
                {
                    if (--set[s[left]] == 0)
                    {
                        set.Remove(s[left]);
                    }
                    ++left;
                }
            }
            return max;
        }
    }


    public class Longest_Substring_with_At_Most_K_Distinct_Characters_2
    {
        /// <summary>
        ///  slide window solution
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int[] count = new int[256];
            int num = 0, i = 0, res = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (count[s[j]]++ == 0) num++;
                if (num > k)
                {
                    while (--count[s[i++]] > 0) ;
                    num--;
                }
                res = Math.Max(res, j - i + 1);
            }
            return res;
        }
    }
}
