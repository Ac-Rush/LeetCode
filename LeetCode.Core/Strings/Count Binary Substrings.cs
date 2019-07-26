using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Count_Binary_Substrings
    {


        public int countBinarySubstrings(String s)
        {
            int ans = 0, prev = 0, cur = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    ans += Math.Min(prev, cur);
                    prev = cur;
                    cur = 1;
                }
                else
                {
                    cur++;
                }
            }
            return ans + Math.Min(prev, cur);
        }
        public int CountBinarySubstrings2(String s)
        {
            int[] groups = new int[s.Length];
            int t = 0;
            groups[0] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    groups[++t] = 1;
                }
                else
                {
                    groups[t]++;
                }
            }

            int ans = 0;
            for (int i = 1; i <= t; i++)
            {
                ans += Math.Min(groups[i - 1], groups[i]);
            }
            return ans;
        }
        public int CountBinarySubstringsMy(string s)
        {
            var dict = new Dictionary<int , int>();
            var count = 0;
            dict[0] = -1;
            var max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count += s[i] == '1' ? 1 : -1;
                if (dict.ContainsKey(count))
                {
                    max = Math.Max(max, i - dict[count]);
                }
                else
                {
                    dict[count] = i;
                }
            }
            return max;
        }
    }
}
