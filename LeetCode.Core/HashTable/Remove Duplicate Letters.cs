using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.HashTable
{
    public class Remove_Duplicate_Letters
    {/*

        Given the string s, the greedy choice (i.e., the leftmost letter in the answer) is the smallest s[i], s.t.
        the suffix s[i .. ] contains all the unique letters. (Note that, when there are more than one smallest s[i]'s, we choose the leftmost one. Why? Simply consider the example: "abcacb".)
        
        After determining the greedy choice s[i], we get a new string s' from s by
        
        removing all letters to the left of s[i],
        removing all s[i]'s from s.
        We then recursively solve the problem w.r.t. s'.

        */
        public string RemoveDuplicateLetters(string s)
        {
            var cs = s.ToCharArray();
            var count = new int[26];
            foreach (var c in cs)
            {
                count[c - 'a']++;
            }

            int pos = 0;  // 
            for (int i = 0; i < s.Length; i++)
            {
                if (cs[i] < cs[pos]) { pos = i; }
                if (--count[cs[i] - 'a'] == 0) break;
            }
            return s.Length == 0 ? "" : cs[pos] + RemoveDuplicateLetters(s.Substring(pos + 1).Replace("" + cs[pos], ""));
        }




        public string RemoveDuplicateLetters2(string s)
        {
            var count = new int[26];
            var used = new int[26];
            foreach (var c in s)
            {
                count[c - 'a']++;
            }

            var result = "";
            foreach (var c in s)
            {
                if (used[c - 'a'] == 0)
                {
                    // pop out duplicate and bigger characters.
                    while (result.Any() && result.Last() >= c &&
                           count[result.Last() - 'a'] > 0)
                    {

                        used[result.Last() - 'a']--;
                        result = result.Remove(result.Length - 1);
                    }

                    result += c;
                    used[c - 'a']++;
                }
                count[c - 'a']--;
            }
            return result;
        }
    }
}
