using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            var set = new int[26];
            var set2 = new int[26];
            foreach (var c in s)
            {
                set[c - 'a'] += 1;
            }
            foreach (var c in t)
            {
                set2[c - 'a'] += 1;
            }
            for (int i = 0; i < set.Length; i++)
            {
                if (set[i] != set2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Valid_Anagram2
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var map = new int[26];
            foreach (var c in s)
            {
                map[c - 'a']++;
            }

            foreach (var c in t)
            {
                if (--map[c - 'a'] < 0) return false;
            }
            return true;
        }
    }
}
