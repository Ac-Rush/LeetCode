using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class First_Unique_Character_in_a_String
    {
        public int FirstUniqChar(string s)
        {
            var set = new int[26];
            foreach (var c in s)
            {
                set[c - 'a'] += 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (set[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
