using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.SlidingWindow
{
    class LengthOfLongestSubstringTwoDistinct
    {
        public int LengthOfLongestSubstringTwoDistinct2(string s)
        {
            int max = 0;
            var map = new Dictionary<char, int>();
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map[c] = 1;
                }

                if (map.Count > 2)  // 这里换成k 就是 k的情况
                {
                    max = Math.Max(max, i - start);

                    while (map.Count > 2)
                    {
                        char t = s[start];
                        int count = map[t];
                        if (count > 1)
                        {
                            map[t]--;
                        }
                        else
                        {
                            map.Remove(t);
                        }
                        start++;
                    }
                }
            }

            max = Math.Max(max, s.Length - start);

            return max;
        }
    }
}
