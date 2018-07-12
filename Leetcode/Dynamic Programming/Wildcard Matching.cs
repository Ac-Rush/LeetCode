using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Wildcard_Matching_Memo
    {
        public bool IsMatch(string s, string p)
        {
           var  mem = new int[s.Length + 1,p.Length + 1];
            return IsMatch(s, p, 0, 0, mem);
        }

        private bool IsMatch(string s, string p, int sStart, int pStart, int[,] memo)
        {
            if (memo[sStart, pStart] == 1)
            {
                return true;
            }
            else if (memo[sStart, pStart] == -1)
            {
                return false;
            }
            if (sStart == s.Length && pStart == p.Length)
            {
                memo[sStart, pStart] = 1;
                return true;
            }
            if (pStart == p.Length)
            {
                memo[sStart, pStart] = -1;
                return false;
            }
            var found = false;
            if ('*' == p[pStart])
            {
                if (IsMatch(s, p, sStart, pStart + 1, memo))
                {
                    found = true;
                }
                if (sStart < s.Length && IsMatch(s, p, sStart + 1, pStart, memo))
                {
                    found = true;
                }
                if (found)
                {
                    memo[sStart, pStart] = 1;
                    return true;
                }
                else
                {
                    memo[sStart, pStart] = -1;
                    return false;
                }
            }
            
            if (sStart >= s.Length) {
                memo[sStart, pStart] = -1;
                return false;  //如此的 结束条件判断
            }
            if ('?' == p[pStart] && IsMatch(s, p, sStart + 1, pStart + 1, memo))
            {
                memo[sStart, pStart] = 1;
                return true;
            }

            if (s[sStart] == p[pStart] && IsMatch(s, p, sStart + 1, pStart + 1, memo))
            {
                memo[sStart, pStart] = 1;
                return true;
            }
            memo[sStart, pStart] = -1;
            return false;
        }
    }

    class Wildcard_Matching_Scan
    {
        public bool IsMatch(String str, String pattern)
        {
            int s = 0, p = 0, match = 0, starIdx = -1;
            while (s < str.Length)
            {
                // advancing both pointers  //如果单个字符相等
                if (p < pattern.Length && (pattern[p] == '?' || str[s] == pattern[p]))
                {
                    s++;
                    p++;
                }
                // * found, only advancing pattern pointer
                else if (p < pattern.Length && pattern[p] == '*')  //如果是 *
                {
                    starIdx = p;
                    match = s;
                    p++;
                }
                // last pattern pointer was *, advancing string pointer
                else if (starIdx != -1)
                {
                    p = starIdx + 1;
                    match++;
                    s = match;
                }
                //current pattern pointer is not star, last patter pointer was not *
                //characters do not match
                else return false;
            }

            //check for remaining characters in pattern
            while (p < pattern.Length && pattern[p] == '*')
                p++;

            return p == pattern.Length;
        }

        private bool IsMatch(string s, string p, int sStart, int pStart, int[,] memo)
        {
            if (memo[sStart, pStart] == 1)
            {
                return true;
            }
            else if (memo[sStart, pStart] == -1)
            {
                return false;
            }
            if (sStart == s.Length && pStart == p.Length)
            {
                memo[sStart, pStart] = 1;
                return true;
            }
            if (pStart == p.Length)
            {
                memo[sStart, pStart] = -1;
                return false;
            }
            var found = false;
            if ('*' == p[pStart])
            {
                if (IsMatch(s, p, sStart, pStart + 1, memo))
                {
                    found = true;
                }
                if (sStart < s.Length && IsMatch(s, p, sStart + 1, pStart, memo))
                {
                    found = true;
                }
                if (found)
                {
                    memo[sStart, pStart] = 1;
                    return true;
                }
                else
                {
                    memo[sStart, pStart] = -1;
                    return false;
                }
            }

            if (sStart >= s.Length)
            {
                memo[sStart, pStart] = -1;
                return false;  //如此的 结束条件判断
            }
            if ('?' == p[pStart] && IsMatch(s, p, sStart + 1, pStart + 1, memo))
            {
                memo[sStart, pStart] = 1;
                return true;
            }

            if (s[sStart] == p[pStart] && IsMatch(s, p, sStart + 1, pStart + 1, memo))
            {
                memo[sStart, pStart] = 1;
                return true;
            }
            memo[sStart, pStart] = -1;
            return false;
        }
    }
}
