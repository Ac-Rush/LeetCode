using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Minimum_Window_Substring
    {
        public string MinWindow(string s, string t)
        {
            if (s == null || s.Length == 0 || t == null || t.Length == 0) return null;
            int[] hash = new int[256]; //character hash
            foreach (var c in t)
            {
                hash[c]++;
            }

            int start = 0, end = 0, count = t.Length, head = 0;
            var minLen = int.MaxValue;
            while (end < s.Length)
            {
                if (hash[s[end++]]-- >= 1) count--; //in t
                while (count == 0)
                { //valid
                    if (end - start < minLen) minLen = end - (head = start);
                    if (hash[s[start++]]++ == 0) count++;  //make it invalid
                }
            }
            return minLen == int.MaxValue ? "" : s.Substring(head, minLen);
        }
    }
}
