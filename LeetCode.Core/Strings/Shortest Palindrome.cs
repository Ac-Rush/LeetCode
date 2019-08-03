using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    /// <summary>
    /// 超时
    /// </summary>
    class Shortest_Palindrome_1
    {
        public string ShortestPalindrome(string s)
        {
            int n = s.Length;
            var rev = new string(s.Reverse().ToArray());
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (s.Substring(0, n - i) == rev.Substring(i))
                    return rev.Substring(0, i) + s;
            }
            return "";
        }
    }


    /// <summary>
    /// O N^2
    /// Approach #2 Two pointers and recursion [Accepted]
    /// 
    /// 1. 前后找相同，    abcxxxxxcba  xxxxxx表示不同的
    /// 2  翻转  xxxxxcba  abcxxxxx
    /// 3. 结果 abc(xxxxx)  + abc的最小回文， + xxxxxcba
    /// </summary>
    class Shortest_Palindrome_2
    {
        public string ShortestPalindrome(string s)
        {
            int n = s.Length;
            int i = 0;
            for (int j = n - 1; j >= 0; j--)
            {
                if (s[i] == s[j])
                    i++;
            }
            if (i == n)
                return s;
            string remain_rev = new string( s.Substring(i, n - i).Reverse().ToArray());
            return remain_rev + ShortestPalindrome(s.Substring(0, i)) + s.Substring(i);
        }
    }


    /// <summary>
    /// KMP  O(n)
    /// </summary>
    class Shortest_Palindrome_3
    {
        public string ShortestPalindrome(string s)
        {
            int n = s.Length;
            var rev = new string(s.Reverse().ToArray());
            string s_new = s + "#" + rev;
            int n_new = s_new.Length;
            var f = new int[n_new];
            for (int i = 1; i < n_new; i++)
            {
                int t = f[i - 1];
                while (t > 0 && s_new[i] != s_new[t])
                    t = f[t - 1];
                if (s_new[i] == s_new[t])
                    ++t;
                f[i] = t;
            }
            return rev.Substring(0, n - f[n_new - 1]) + s;
        }
    }
}
