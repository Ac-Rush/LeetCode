using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Verifying_an_Alien_Dictionary
    {
        int[] mapping = new int[26];
        public bool IsAlienSorted(String[] words, String order)
        {
            for (int i = 0; i < order.Length; i++)
                mapping[order[i] - 'a'] = i;
            for (int i = 1; i < words.Length; i++)
                if (compare(words[i - 1], words[i]) > 0)
                    return false;
            return true;
        }

        int compare(String s1, String s2)
        {
            int n = s1.Length, m = s2.Length, cmp = 0;
            for (int i = 0, j = 0; i < n && j < m && cmp == 0; i++, j++)
            {
                cmp = mapping[s1[i] - 'a'] - mapping[s2[j] - 'a'];
            }
            return cmp == 0 ? n - m : cmp;
        }

    }
}
