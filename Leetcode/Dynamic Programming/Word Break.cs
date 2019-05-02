using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Word_Break
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] f = new bool[s.Length + 1];
            var set = new HashSet<string>();
            foreach (var word in wordDict)
            {
                set.Add(word);
            }
            f[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (f[j] && set.Contains(s.Substring(j, i-j)))
                    {
                        f[i] = true;
                        break;
                    }
                }
            }

            return f[s.Length];
        }
    }

    /// <summary>
    /// 超时  时间复杂度 n^n
    /// </summary>
    class Word_Break_BF
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            return word_Break(s, new HashSet<string>(wordDict), 0);
        }
        public bool word_Break(String s, HashSet<string> wordDict, int start)
        {
            if (start == s.Length)
            {
                return true;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (wordDict.Contains(s.Substring(start, end - start )) && word_Break(s, wordDict, end))
                {
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// 用了 memoization 把时间复杂度降到了 N^2
    /// </summary>
    class Word_Break_Memo
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            return word_Break(s, new HashSet<string>(wordDict), 0, new bool?[s.Length]);
        }
        public bool word_Break(String s, HashSet<string> wordDict, int start, bool?[] memo)
        {
            
            if (start == s.Length)
            {
                return true;
            }
            if (memo[start] != null)
            {
                return memo[start].Value;
            }
            var result = false;
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (wordDict.Contains(s.Substring(start, end - start)) && word_Break(s, wordDict, end, memo))
                {
                    result= true;
                }
            }
            memo[start] = result;
            return result;
        }
    }


    class Word_Break_DP
    {
        /*
         * 
         *   my solution 
         */ 
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var set = new HashSet<string>(wordDict);
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    var word = s.Substring(j, i - j + 1);
                    if (set.Contains(word) && dp[j])
                    {
                        dp[i + 1] = true; //这里是 i+1
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
    }
}
