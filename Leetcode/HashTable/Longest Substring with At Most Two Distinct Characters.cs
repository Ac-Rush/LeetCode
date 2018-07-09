using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{

    class Longest_Substring_with_At_Most_Two_Distinct_Characters_2Pointer
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {

            int left1 = -1;
            int left2 = -1;
            int len = 0;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (left1 == -1 || s[i] == s[left1])
                {
                    left1 = i;
                    len++;
                    max = Math.Max(max, len);
                }
                else if (left2 == -1 || s[i] == s[left2])
                {
                    left2 = i;
                    len++;
                    max = Math.Max(max, len);
                }
                else
                {
                    if (left1 < left2) { len = i - left1; left1 = i; }
                    else { len = i - left2; left2 = i; }
                }
            }
            return max;
        }
    }
    /// <summary>
    /// Sliding windows的做法
    /// </summary>
    class Longest_Substring_with_At_Most_Two_Distinct_Characters_SlidingWindow
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {

            var dict = new int[256];
            int start = 0, len = 0, count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                dict[s[i]]++;
                if (dict[s[i]] == 1)
                { // new char
                    count++;
                    while (count > 2)
                    {
                        dict[s[start]]--;
                        if (dict[s[start]] == 0) count--;
                        start++;
                    }
                }
                if (i - start + 1 > len) len = i - start + 1;
            }
            return len;
        }
    }
}
