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


    class Wildcard_Matching_DP
    {
        public bool IsMatch(String s, String p)
        {
            var match = new bool[s.Length + 1,p.Length + 1];
            match[s.Length,p.Length] = true; //从后往前，最后面是match的
            for (int i = p.Length - 1; i >= 0; i--)
            {
                if (p[i] != '*')
                    break;
                else
                    match[s.Length,i] = true;
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = p.Length - 1; j >= 0; j--)
                {
                    if (s[i] == p[j] || p[j] == '?')  //如果字母相同，那么就  match[i,j] = match[i + 1,j + 1];
                        match[i,j] = match[i + 1,j + 1];
                    else if (p[j] == '*')
                        match[i,j] = match[i + 1,j] || match[i,j + 1];
                    else
                        match[i,j] = false;
                }
            }
            return match[0,0];
        }
    }

    //这样做 也可以，但是感觉不如上面的简单
    class Wildcard_Matching_DP2
    {
        public bool IsMatch(String s, String p)
        {
            var match = new bool[s.Length + 1, p.Length + 1];
            match[0,0] = true; //从后往前，最后面是match的
            for (int i = 1; i<= p.Length; i++)
            {
                if (p[i -1] != '*')
                    break;
                else
                    match[0, i] = true;
            }
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (s[i-1] == p[j-1] || p[j-1] == '?')  //如果字母相同，那么就  match[i,j] = match[i + 1,j + 1];
                        match[i, j] = match[i - 1, j - 1];
                    else if (p[j -1] == '*')
                        match[i, j] = match[i -1, j] || match[i, j -1];
                    else
                        match[i, j] = false;
                }
            }
            return match[s.Length, p.Length];
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

       
    }
}
